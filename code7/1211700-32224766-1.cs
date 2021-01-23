	/// <summary>
	///     Synchronously invoke the callback in the SynchronizationContext.
	/// </summary>
	public override void Send(SendOrPostCallback d, Object state)
	{
		// Call the Invoke overload that preserves the behavior of passing
		// exceptions to Dispatcher.UnhandledException.  
		if(BaseCompatibilityPreferences.GetInlineDispatcherSynchronizationContextSend() && 
		   _dispatcher.CheckAccess())
		{
			// Same-thread, use send priority to avoid any reentrancy.
			_dispatcher.Invoke(DispatcherPriority.Send, d, state);
		}
		else
		{
			// Cross-thread, use the cached priority.
			_dispatcher.Invoke(_priority, d, state);
		}
	}
