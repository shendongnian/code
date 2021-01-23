    public class ConsoleInteractionService : IInteractionService
    {
        public WinFormsInteractionService()
        {
        }
        private readonly string _showErrorReportDialogFormatString = //...
    
        public void ShowErrorReportDialog(Exception e, SqlCommand cmd)
        {
            Console.WriteLine(_showErrorReportDialogFormatString, e, cmd);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
