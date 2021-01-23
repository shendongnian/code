    class Foo
    {
        public Foo(ILogger logger)
        {
            this._loggerName = logger.Name;
        }
        private readonly String _loggerName; 
        public String LoggerName 
        {
            get 
            {
                return this._loggerName;
            }
        }
    }
