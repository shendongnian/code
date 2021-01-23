    public class Logger
    {
        public enum LogLevel
        {
            Low,
            Medium,
            High
        };
        private readonly string _filePath;
        public Logger(string filePath)
        {
            //logStream = new StreamWriter(logFilePath, false);
            _filePath = filePath;
        }
        public void LogMessage(string message)
        {
            LogMessage(message, LogLevel.Low, false);
        }
        public void LogMessage(string message, LogLevel level, bool excludeFromLogFile)
        {
            using (var fileStream = new FileStream(_filePath, FileMode.Append, FileAccess.Write))
            {
                using (var writer = new StreamWriter(fileStream) {AutoFlush = true})
                {
                    var prefix = string.Empty;
                    var color = ConsoleColor.White;
                    switch (level)
                    {
                        case LogLevel.Medium:
                            prefix = "?";
                            color = ConsoleColor.Yellow;
                            break;
                        case LogLevel.High:
                            prefix = "!";
                            color = ConsoleColor.Red;
                            break;
                    }
                    if (!excludeFromLogFile)
                    {
                        writer.WriteLine("{0} {1} {2}", prefix, DateTime.Now, message);
                    }
                    Console.ForegroundColor = color;
                    Console.WriteLine("{0}", message);
                    Console.ResetColor();
                }
            }
        }
    }
