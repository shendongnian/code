	public class Log4netAdapter<T> : ILogger
	{
		private static readonly log4net.ILog logger = LogManager.GetLogger(typeof(T));
		public void Log(LogEntry entry)
		{
			if(entry.LoggingEventType == LoggingEventType.Information)
				logger.Info(entry.Message, entry.Exception);
			else if(entry.LoggingEventType == LoggingEventType.Warning)
				logger.Warn(entry.Message, entry.Exception);
			else if(entry.LoggingEventType == LoggingEventType.Error)
				logger.Error(entry.Message, entry.Exception);
			else
				logger.Fatal(entry.Message, entry.Exception);
		}
	}
