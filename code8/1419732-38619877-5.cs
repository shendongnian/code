    public class LoggerDatabaseProvider : ILoggerProvider
    {
        private IWorldRepository _repo;
        public LoggerDatabaseProvider(IWorldRepository repo)
        {
            _repo = repo;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new Logger(categoryName, _repo);
        }
        public void Dispose()
        {
        }
        public class Logger : ILogger
        {
            private readonly string _categoryName;
            private readonly IWorldRepository _repo;
            public Logger(string categoryName, IWorldRepository repo)
            {
                _repo = repo;
                _categoryName = categoryName;
            }
            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                if (logLevel == LogLevel.Critical || logLevel == LogLevel.Error || logLevel == LogLevel.Warning)
                    RecordMsg(logLevel, eventId, state, exception, formatter);
            }
            private void RecordMsg<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                _repo.Log(new Log
                {
                    LogLevel = logLevel.ToString(),
                    CategoryName = _categoryName,
                    Msg = formatter(state, exception),
                    User = "username",
                    Timestamp = DateTime.Now
                });
            }
            public IDisposable BeginScope<TState>(TState state)
            {
                return new NoopDisposable();
            }
            private class NoopDisposable : IDisposable
            {
                public void Dispose()
                {
                }
            }
        }
    }
