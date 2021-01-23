    public class Log4NetProvider : ILoggerProvider
    {
        private static readonly NoopLogger _noopLogger = new NoopLogger();
        private readonly Func<string, bool> _filterFunc;
        private readonly ConcurrentDictionary<string, Log4NetLogger> _loggers = new ConcurrentDictionary<string, Log4NetLogger>();
        public Log4NetProvider(Func<string, bool> filterFunc = null)
        {
            this._filterFunc = filterFunc != null ? filterFunc : x => true;
        }
        public ILogger CreateLogger(string name)
        {
            if (!_filterFunc(name))
                return _noopLogger;
            return _loggers.GetOrAdd(name, x => new Log4NetLogger(name));
        }
        public void Dispose()
        {
            _loggers.Clear();
        }
        private class NoopLogger : ILogger
        {
            public IDisposable BeginScopeImpl(object state)
            {
                return null;
            }
            public bool IsEnabled(LogLevel logLevel)
            {
                return false;
            }
            public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
            {
            }
        }
    }
