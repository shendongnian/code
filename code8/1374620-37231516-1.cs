    public class FileLogger : ILogger
    {
        private readonly ILogFileProvider logFileProvider;
        public FileLogger(ILogFileProvider logFileProvider)
        {
            this.logFileProvider = logFileProvider;
        }
    
        public void Log(string message)
        {
             using (var writer = new StreamWriter(this.currentLogFile))
             {
                  writer.WriteLine(message);
             }
        }
    
        private string currentLogFile =>
             this.logFileProvider.PathToLogFile;
    }
