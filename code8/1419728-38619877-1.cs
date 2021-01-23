    public class LoggerFileProvider : ILoggerProvider
    {
        private readonly string _logFilePath;
        public LoggerFileProvider(string logFilePath)
        {
            _logFilePath = logFilePath;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new Logger(categoryName, _logFilePath);
        }
        public void Dispose()
        {
        }
        public class Logger : ILogger
        {
            private readonly string _categoryName;
            private readonly string _path;
            public Logger(string categoryName, string logFilePath)
            {
                _path = logFilePath;
                _categoryName = categoryName;
            }
            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                try
                {
                    RecordMsg(logLevel, eventId, state, exception, formatter);
                }
                catch (Exception ex)
                {
                    //this is being used in case of error 'the process cannot access the file because it is being used by another process', could not find a better way to resolve the issue
                    RecordMsg(logLevel, eventId, state, exception, formatter);
                }
            }
            private void RecordMsg<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                string msg = $"{logLevel} :: {_categoryName} :: {formatter(state, exception)} :: username :: {DateTime.Now}";
                using (var writer = File.AppendText(_path))
                {
                    writer.WriteLine(msg);
                }
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
