    public async Task<string> FooAsync()
    {
    	// Will give you the sync ctx of the calling thread
    	// which, in this case, happens to be the UI thread
    	var ctx = SynchronizationContext.Current;
    
    	return await Task.Run(() => 
    	{
    		if (ctx != null)
    		{
    			// Use ctx here
    
    			// button1.Text = ctx.GetType().Name;
    			Debugger.Break();
    		}
    
    		return "Hello";
    	});
    }
