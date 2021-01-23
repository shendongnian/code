	public void MyMethod( ... )
	{
	 ...
        // Placeholder for thread to kill if the action times out.
        Thread threadToKill = null;
        Action wrappedAction = () => 
        {
            // Take note of the action's thread. We may need to kill it later.
            threadToKill = Thread.CurrentThread;
            ...
            /* DO STUFF HERE */
            ...
		};
        // Now, execute the action. We'll deal with the action timeouts below.
        IAsyncResult result = wrappedAction.BeginInvoke(null, null);
        // Set the timeout to 10 minutes.
        if (result.AsyncWaitHandle.WaitOne(10 * 60 * 1000))
        {
            // Everything was successful. Just clean up the invoke and get out.
            wrappedAction.EndInvoke(result);
        }
        else 
        {
            // We have timed out. We need to abort the thread!! 
            // Don't let it continue to try to do work. Something may be stuck.
            threadToKill.Abort();
            throw new TimeoutException("This code block timed out");
        }
	 ...
	}
