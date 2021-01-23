    public interface ILogger
	{
		void Write(LogLevel level, string message, Exception exception);
    }
	public class Logger : ILogger
	{
		public void Write(LogLevel level, string message, Exception exception)
			{
					message.Dump(level.ToString());
			}
	}
    public enum LogLevel
	{
	  /// <summary>
	  /// The lowest level, for any information that is considered verbose.
	  /// </summary>
	  Verbose,
	  /// <summary>
	  /// The second lowest level, for tracing the workflow in detail logging.
	  /// </summary>
	  Trace,
	  /// <summary>
	  /// For logging information that may help debugging problems.
	  /// </summary>
	  Debug,
	  /// <summary>
	  /// A non-critical error has occurred that will not interrupt the application but may degrade the user experience.
	  /// </summary>
	  Warn,
	  /// <summary>
	  /// For interesting business or technical actions such as a process starting or a request being made.
	  /// </summary>
	  Info,
	  /// <summary>
	  /// For errors that need immediate attention.
	  /// </summary>
	  Error,
	  /// <summary>
	  /// For catastrophic failures.
	  /// </summary>
	  Fatal
	}
	
