    using NLog;
    
    public static class LogService {
        private static Logger logger = LogManager.GetLogger("Logs");
        private static object lockObject = new object();
        
        public static void Log(string loggerName)
        {
            lock (lockObject)
            {
                LogManager.Configuration.Variables["LoggerName"] = loggerName;
                logger.Log("some message");
            }
        }
    }
