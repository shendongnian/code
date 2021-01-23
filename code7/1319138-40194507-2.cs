    public static class Utils
    {
    	public static Task WhenClicked(this Control target)
    	{
    		var tcs = new TaskCompletionSource<object>();
    		EventHandler onClick = null;
    		onClick = (sender, e) =>
    		{
    			target.Click -= onClick;
    			tcs.TrySetResult(null);
    		};
    		target.Click += onClick;
    		return tcs.Task;
    	}
    }
