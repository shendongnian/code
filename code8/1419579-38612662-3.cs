    public enum LogFormat
    {
        Message,
        Hash,
        Error,
        Dash
    }
    public interface ILogger
    {
        void Log(string message, LogFormat format);
        void LogToConsole(string message);
        void ClearLog();
    }
    public class FileSystemLogger : ILogger
    {
        public void Log(string message, LogFormat format)
        {
            // Your filesystem logging code here...
        }
        public void LogToConsole(string message)
        {
            Console.WriteLine(message);
        }
        public void ClearLog()
        {
            // Your filesystem logging code here...
        }
    }
    public class DatabaseLogger : ILogger
    {
        public void Log(string message, LogFormat format)
        {
            // Your database logging code here...
        }
        public void LogToConsole(string message)
        {
            Console.WriteLine(message);
        }
        public void ClearLog()
        {
            // Your database logging code here...
        }
    }
