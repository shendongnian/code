	public sealed class Logger<T> : ILogger
    {
		private static readonly ILogger logger = 
			new Common.Logging.NLogLogger(typeof(T).FullName);
		
		// Implement ILogger methods here
		void ILogger.Log(string message) {
			// Delegate to real logger
			logger.Log(message);
		}
	}
