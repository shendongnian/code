    public enum LogFormat
        {
            Message,
            Hash,
            Error,
            Dash
        }
        public static void Log(string message, LogFormat format = LogFormat.Message)
        {
            lock (Lock)
            {
                try
                {
                    string logFormat = $"{GetDate()} @ {GetTime(),-8} |  >";
                    switch (format)
                    {
                        case LogFormat.Message:
                            message = $"{message}{Environment.NewLine}";
                            break;
                        case LogFormat.Hash:
                            message = $"{logFormat} ### {message}{Environment.NewLine}";
                            break;
                        case LogFormat.Error:
                            message = $"{logFormat} ERROR {message}{Environment.NewLine}";
                            break;
                        case LogFormat.Dash:
                            message = $"{logFormat} --- {message} --- {Environment.NewLine}";
                            break;
                        default:
                            message = $"{logFormat} {message}{Environment.NewLine}";
                            break;
                    }
                    LogToConsole(message);
                    File.AppendAllText(LogFilePath, message);
                }
                catch (DirectoryNotFoundException ex)
                {
                    LogToConsole($"Error writing log: {ex.Message}");
                    throw;
                }
            }
        }
