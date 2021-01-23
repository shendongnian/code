    public class LoggingStopwatch : IDisposable
    {
        public LoggingStopwatch(ILogger logger, LogLevel level, string message)
        {
            this.logger = logger;
            this.logLevel = logLevel;
            this.message = message;
            this.stopwatch = new Stopwatch();
            this.Start();
        }
    
        public void Start()
        {
            // compare this.logLevel with the one set in this.logger
            // and return if no output will be generated
            // start stopwatch, log entry
        }
    
        public void Stop()
        {
            // stop stopwatch, log entry
        }
    
        public void Dispose()
        {
            this.Stop();
        }
    }
