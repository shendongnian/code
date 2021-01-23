    public static void setEventLogAppenderMaximumSize(log4net.ILog aLogger)
    {
    	log4net.Appender.IAppender[] logAppenders = aLogger.Logger.Repository.GetAppenders();
    	if (logAppenders != null && logAppenders.Length > 0)
    	{
    		string logName = ((log4net.Appender.EventLogAppender)logAppenders[0]).LogName;
    
    		EventLog[] eventLogs = EventLog.GetEventLogs();
    		foreach (EventLog e in eventLogs)
    		{
    			if (e.Log == logName)
    			{
    				int newLogSizeInKB = 102400;    //10MB
    
    				if (e.MaximumKilobytes < newLogSizeInKB)
    				{
    					e.MaximumKilobytes = newLogSizeInKB;
    				}
    				return;
    			}
			}
    	}
    }
