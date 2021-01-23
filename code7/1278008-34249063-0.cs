        private static void InitLogging()
        {
            log4net.Config.XmlConfigurator.Configure();
            _logger = Common.Logging.LogManager.GetLogger(typeof(Program));
            _logger.Debug("Logging initialized");
        }
