I know I'm late to the party but I've just written an extension method which glues up the calls to BeginInvoke() and EndInvoke() into Task Parallel Library (TPL):
    public static Task<PSDataCollection<PSObject>> InvokeAsync(this PowerShell ps, CancellationToken cancel)
    {
    	return Task.Factory.StartNew(() =>
    	{
    		// Do the invocation
    		var invocation = ps.BeginInvoke();
    		WaitHandle.WaitAny(new[] { invocation.AsyncWaitHandle, cancel.WaitHandle });
    
    		if (cancel.IsCancellationRequested)
    		{
    			ps.Stop();
    		}
    
    		cancel.ThrowIfCancellationRequested();
    		return ps.EndInvoke(invocation);
    	});
    }
