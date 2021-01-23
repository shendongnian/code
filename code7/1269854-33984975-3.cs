	// First try getting the current synchronization context.
	// If the current context is really just the base SynchronizationContext type, 
	// which is intended to be equivalent to not having a current SynchronizationContext at all, 
	// then ignore it.  This helps with performance by avoiding unnecessary posts and queueing
	// of work items, but more so it ensures that if code happens to publish the default context 
	// as current, it won't prevent usage of a current task scheduler if there is one.
	var syncCtx = SynchronizationContext.CurrentNoFlow;
	if (syncCtx != null && syncCtx.GetType() != typeof(SynchronizationContext))
	{
		tc = new SynchronizationContextAwaitTaskContinuation(
					syncCtx, continuationAction, flowExecutionContext, ref stackMark);
	}
	else
	{
		// If there was no SynchronizationContext, then try for the current scheduler.
		// We only care about it if it's not the default.
		var scheduler = TaskScheduler.InternalCurrent;
		if (scheduler != null && scheduler != TaskScheduler.Default)
		{
			tc = new TaskSchedulerAwaitTaskContinuation(
					scheduler, continuationAction, flowExecutionContext, ref stackMark);
		}
	}
