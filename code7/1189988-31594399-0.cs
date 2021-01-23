    public class Logger
    {
        private Lazy<LogWriter> logWriter = new Lazy<LogWriter>(() =>
            {
                LogWriterFactory factory = new LogWriterFactory();
                return factory.Create();
            });
        public LogWriter LogWriter
        {
            get { return logWriter.Value; }
        }            
    }
