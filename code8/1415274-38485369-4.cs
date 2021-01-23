	public static class Logger
	{
		public static Action<string> LogAction { get;set; }
		[Conditional("LoggingEnabled")]
		public static void LogConditional(string message)
		{
			var logAction = LogAction;
			if(logAction != null)
				logAction(message);
		}
		
		public static void Log(string message)
		{
			var logAction = LogAction;
			if(logAction != null)
				logAction(message);
		}
	}
