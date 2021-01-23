    public static class LoggerHelper
    {
        [ThreadStatic]
        static public ILogger _logger;
        static public ILogger Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }
    }
