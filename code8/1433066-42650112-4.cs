    public class Logger<T> : ILogger<T>
    {
        private readonly ILogger _logger;
        public Logger(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger(TypeNameHelper.GetTypeDisplayName(typeof(T)));
        }
        void ILogger.Log<TState>(...)
        {
            _logger.Log(logLevel, eventId, state, exception, formatter);
        }
    }
