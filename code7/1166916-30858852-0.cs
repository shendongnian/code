    public static class LoggingFactory
    {
        private static ILog _logger;
        private static CreateLogger()
        {
            // Some log4net initialization
            return LogManager.GetLogger("Logger");
        }
        public static GetLogger()
        {
            return _logger ?? (_logger = CreateLogger());
        }
    }
    public class AnyClassOfYourWholeSolution
    {
        LoggingFactory.GetLogger().DebugFormat("{0} {1}", a, b);
    }
