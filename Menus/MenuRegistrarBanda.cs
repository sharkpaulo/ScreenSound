using OpenAI_API;
using ScreenSound.Modelos;

namespace ScreenSound.Menus
{
    internal class MenuRegistrarBanda : Menu
    {
        public override void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            base.Executar(bandasRegistradas);
            ExibirTituloDaOpcao("Registro das bandas");
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!;
            Banda banda = new Banda(nomeDaBanda);
            bandasRegistradas.Add(nomeDaBanda, banda);
            var client = new OpenAIAPI("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");
            var chat = client.Chat.CreateConversation();
            chat.AppendSystemMessage($"Resuma {banda.Nome} em um paragrafo");
            string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
            banda.Resumo = resposta;
            Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
            //Thread.Sleep(4000);
            Console.Clear();
        }
    }
}
