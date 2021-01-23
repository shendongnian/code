    enum LoggerType { Logger1, Logger2 }
    internal class MyLogger : ILogger1, ILogger2
    {
        private readonly ILog _log;
        public MyLogger(LoggerType loggerName)
        {
            switch (loggerName)
            {
                case LoggerType.Logger1:
                    _log = LogManager.GetLogger("first-log");
                    break;
                case LoggerType.Logger2:
                    _log = LogManager.GetLogger("second-log");
                    break;
                default:
                    throw new ArgumentException("Invalid logger name", "loggerName");
            }
        }
        public void Info(object message)
        {
            _log.Info(message);
        }
        public void Info(string format, params object[] args)
        {
            _log.InfoFormat(format, args);
        }
    } 
