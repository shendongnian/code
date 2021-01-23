    /// <summary>
    /// Executing method without ShimsContext being created.
    /// </summary>
    /// <param name="action">Action to execute.</param>
    /// <remarks>Usage: ExecuteWithoutShimsContext(()=> TestMethod()); </remarks>
    public static void ExecuteWithoutShimsContext(FakesDelegates.Action action)
    {
    	if (action == null)
    	{
    		throw new ArgumentNullException("action");
    	}
    	using (UnitTestIsolationRuntime.AcquireProtectingThreadContext())
    	{
    		action();
    	}
    }
