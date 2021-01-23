    public static class LoggingFactory
    {
        private static ILog _logger;
        private static ILog CreateLogger()
        {
            // Some log4net initialization
            return LogManager.GetLogger("Logger");
        }
        public static ILog GetLogger()
        {
            return _logger ?? (_logger = CreateLogger());
        }
    }
    public class AnyClassOfYourWholeSolution
    {
        LoggingFactory.GetLogger().DebugFormat("{0} {1}", a, b);
    }
