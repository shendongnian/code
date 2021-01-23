    public interface ILogger
    {
        void Debug(string ip, string message);
        void Info(string ip, string message);
        void Error(string ip, string message);
    }
    public class Log4NetLogger : ILogger
    {
        private ILog  _logger;
        public Log4NetLogger() 
        {
            // Some log4net initialization
            _logger = LogManager.GetLogger("Logger");
        }
        public void Debug(string ip, string message)
        {
            // ...
        }
        public void Info(string ip, string message)
        {
            // ...
        }
        public void Error(string ip, string message)
        {
            // ...
        }
    }
    public static class LoggingFactory
    {
        private static ILogger _loggerAdapter;
        private static Initialize(ILogger adapter)
        {
            _loggerAdapter = adapter;
        }
        public static GetLogger()
        {
            return _logger;
        }
    }
    public class BeginningOfYourProject 
    {
        // Main() or Global.asax or Program.cs etc.
        LoggingFactory.Initialize(new Log4NetLogger());
    }
    public class AnyClassOfYourWholeProject
    {
        LoggingFactory.GetLogger().Debug(ip, message);
    }
