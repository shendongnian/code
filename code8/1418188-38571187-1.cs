    public class Logger : IMessageLogger
    {
        private IMessageLogger _messageLogger;
        private static Logger _instance;
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Pick one:
                    _instance = new Logger(new FileLogger("SomePath"));
                    _instance = new Logger(new ConsoleLogger());
                }
                return _instance;
            }
        }
        private Logger(IMessageLogger messageLogger)
        {
            _messageLogger = messageLogger;
        }
        public void Log(string message)
        {
            _messageLogger.Log(message);
        }
    }
