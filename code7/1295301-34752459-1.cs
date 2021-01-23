    public class ConsoleInteractionService : IInteractionService
    {
        public WinFormsInteractionService()
        {
        }
    
        public void ShowErrorReportDialog(Exception e, SqlCommand cmd)
        {
            var message = BuildConsoleMessage(e, cmd);
            Console.WriteLine(message);
        }
        private string BuildConsoleMessage(Exception e, SqlCommand cmd)
        {
            //...
        }
    }
