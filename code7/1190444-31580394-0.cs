    public class Logging
    {
        public readonly ILog log = LogManager.GetLogger(typeof(Logging));
        public static Logging()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        public static void LogError(string exception)
        {
            log.Error(exception);
        }
    }
