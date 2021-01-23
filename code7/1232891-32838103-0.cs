    public static class Utils
    {
    	public static Task WhenClicked(this Button button)
    	{
    		var tcs = new TaskCompletionSource<object>();
    		EventHandler onClick = null;
    		onClick = (sender, e) =>
    		{
    			button.Click -= onClick;
    			tcs.TrySetResult(null);
    		};
    		button.Click += onClick;
    		return tcs.Task;
    	}
    }
