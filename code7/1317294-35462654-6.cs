    public class Logger
    {    
    #region Singleton pattern
        // this is the static one-and-only logger instance, alive
        // throughout the lifetime of your application
        private static readonly Logger _instance = new Logger();
        public static Logger Instance
        {
            get { return _instance; }
        }
        
        // private empty constructor is here to ensure 
        // that you can only access this class through the
        // Logger.Instance static property
        private Logger() { }
        
    #endregion
        private readonly object _lock = new object();
        private readonly List<string> _messages = new List<string>(); 
        public void Append(string message)
        {
            lock (_lock)
                _messages.Add(message);
        }
        public string Merge()
        {
            lock (_lock)
            {
                var result = string.Join(Environment.NewLine, _messages);
                _messages.Clear();
                return result;
            }
        }
    }
