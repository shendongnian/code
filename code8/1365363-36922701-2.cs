    public class UnhandledExceptionLogger : ILogger
    {
        private readonly IErrorRepo _repo;
        public UnhandledExceptionLogger(IErrorRepo repo)
        {
            _repo = repo;
        }
        public IDisposable BeginScopeImpl(object state) =>
            new NoOpDisposable();
        public bool IsEnabled(LogLevel logLevel) =>
            logLevel == LogLevel.Critical || logLevel == LogLevel.Error;
        public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                _repo.SaveException(exception);
            }
        }
        private sealed class NoOpDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
