    public enum LogSeverity
    {
        // enum items
    }
    public interface ILogger
    {
        void Log(string message);
  
        void Log(string message, LogSeverity severity);
    }
