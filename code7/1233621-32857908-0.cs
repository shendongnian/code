    // Example of a class that needs to use logging
    public class MyClass
    {
        private LoggerHelper _logger;
        public MyClass(int id)
        {
            _logger = new LoggerHelper(LogManager.GetCurrentClassLogger());
            // Per-instance values
            _logger.Set("ID", id);
        }
        public void DoStuff()
        {
            _logger.Debug("My name is {0}", "Ed");
        }
    }
    // Example of a "stateful" logger
    public class LoggerHelper
    {
        private Logger _logger;
        private Dictionary<string, object> _properties;
        
        public LoggerHelper(Logger logger)
        {
            _logger = logger;
            _properties = new Dictionary<string, object>();
        }
        public void Set(string key, object value)
        {
            _properties.Add(key, value);
        }
        public void Debug(string format, params object[] args)
        {
            _logger.Debug()
                .Message(format, args)
                .Properties(_properties)
                .Write();
        }
    }
