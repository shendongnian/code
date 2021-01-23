    public interface ILog
    {
        void Debug(string message, params object[] args);
    }
    public class SeriLogger : ILog
    {
        static SeriLogger ()
        {
            LoggerConfig = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace();
        }
        private readonly ILogger logger;
        private static readonly LoggerConfiguration LoggerConfig;
        public SeriLogger(Type type)
        {
            logger = LoggerConfig.CreateLogger().ForContext(type);
        }
        public void Debug(string message, params object[] args)
        {
            logger.Debug(message, args);
        }
    }
