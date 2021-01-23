    class ConsoleProgress : IProgress<string>
    {
        public void ReportProgress(string text)
        {
            Console.WriteLine(text);
        }
    }
