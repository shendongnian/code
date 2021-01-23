	// Get the current SynchronizationContext on the current thread
	public static SynchronizationContext Current 
	{
		get      
		{
			return Thread.CurrentThread.GetExecutionContextReader().SynchronizationContext ??
				   GetThreadLocalContext();
		}
	}
