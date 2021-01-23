    public async Task<string> FooAsync()
    {
    	return await Task.Run(() => 
    	{
    		// Will get us the sync context of the worker,
    		// which there is none, thus null
    		var ctx = SynchronizationContext.Current;
    
    		if (ctx != null)
    		{
    			// Use ctx here
    
    			// button1.Text = ctx.GetType().Name;
    			Debugger.Break();
    		}
    
    		return "Hello";
    	});
    }
