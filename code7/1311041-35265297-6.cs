    public class Log4NetProvider : ILoggerProvider
    {
        private static readonly NoopLogger _noopLogger = new NoopLogger();
        private readonly Func<string, bool> _sourceFilterFunc;
        private readonly ConcurrentDictionary<string, Log4NetLogger> _loggers = new ConcurrentDictionary<string, Log4NetLogger>();
        public Log4NetProvider(Func<string, bool> sourceFilterFunc = null)
        {
            _sourceFilterFunc = sourceFilterFunc != null ? sourceFilterFunc : x => true;
        }
        public ILogger CreateLogger(string name)
        {
            if (!_sourceFilterFunc(name))
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
