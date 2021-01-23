    public sealed class AsyncTask
    {
    	public static void Run(Func<Task> asyncFunc)
    	{
    		var originalContext = SynchronizationContext.Current;
    		bool restoreContext = false;
    		try
    		{
    			if (originalContext != null && originalContext.GetType() != typeof(SynchronizationContext))
    			{
    				restoreContext = true;
    				SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
    			}
    			var task = asyncFunc();
    			task.GetAwaiter().GetResult();
    		}
    		finally
    		{
    			if (restoreContext) SynchronizationContext.SetSynchronizationContext(originalContext);
    		}
    	}
    	public static TResult Run<TResult>(Func<Task<TResult>> asyncFunc)
    	{
    		var originalContext = SynchronizationContext.Current;
    		bool restoreContext = false;
    		try
    		{
    			if (originalContext != null && originalContext.GetType() != typeof(SynchronizationContext))
    			{
    				restoreContext = true;
    				SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
    			}
    			var task = asyncFunc();
    			return task.GetAwaiter().GetResult();
    		}
    		finally
    		{
    			if (restoreContext) SynchronizationContext.SetSynchronizationContext(originalContext);
    		}
    	}
    }
