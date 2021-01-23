    public sealed class MsLoggerAdapter : MyApp.ILogger
	{
		private readonly Func<Microsoft.Framework.Logging.ILogger> factory;
		public MsLoggerAdapter(Func<Microsoft.Framework.Logging.ILogger> factory) {
			this.factory = factory;
		}
		
		public void Log(LogEntry entry) {
			var logger = this.factory();
			LogLevel level = ToLogLevel(entry.Severity);
			logger.Log(level, 0, entry.Message, entry.Exception,
				(msg, ex) => ex != null ? ex.Message : msg.ToString());
		}
		
		private static LogLevel ToLogLevel(LoggingEventType severity) { ... }
	}
