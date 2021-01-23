    // I'm thinking of Log4Net here, but of course something else could be used.
	public static Task LogExceptions(this Task task, ILog log)
	{
	  return task.ContinueWith(ta => LogFailedTask(ta, log), TaskContinuationOptions.OnlyOnFaulted);
	}
	private static void LogFailedTask(Task ta, ILog log)
	{
	  var aggEx = ta.Exception;
	  if(aggEx != null)
	  {
		log.Error("Error in asynchronous event");
		int errCount = 0;
		foreach(var ex in aggEx.InnerExceptions)
		  log.Error("Asynchronous error " + ++errCount, ex);
	  }
	}
