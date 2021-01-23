    public class Logger
    {
    	public Action<string> LogAction { get;set; }
    	
        [Conditional("LoggingEnabled")]
    	public void Log(string message)
    	{
    		var logAction = LogAction;
    		
    		if(logAction != null)
    			logAction(message);
    	}
    }
