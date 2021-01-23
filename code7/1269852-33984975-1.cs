	// Get the last SynchronizationContext that was set explicitly
	// (not flowed via ExecutionContext.Capture/Run)        
	internal static SynchronizationContext CurrentNoFlow
	{
		[FriendAccessAllowed]
		get
		{
			return Thread.CurrentThread.GetExecutionContextReader()
									   .SynchronizationContextNoFlow ?? GetThreadLocalContext();
		}
	}
	
