    public class Logger : ILogger
    {
        private static ILog _log = LogManager.GetLogger("ErrorLogger");
        void ILogger.Info(object msg)
        {
            _log.Info(msg);
        }
        ....
    }
