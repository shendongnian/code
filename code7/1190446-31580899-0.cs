    public static class Logging
    {
        private static ILog _logger = null;
        private static log4net.ILog Logger
        {
            get
            {
                if(_logger == null)
                {
                    _logger = LogManager.GetLogger(typeof(Logging));
                    log4net.Config.XmlConfigurator.Configure();
                }
                return _logger;
            }
        }
        // Better to use Exception object. This gives you more details
        public static void LogError(string msg, Exception ex)
        {
             Logger.Error(msg, ex);
        }
