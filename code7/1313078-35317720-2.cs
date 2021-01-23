    public static class AsyncUtils
    {
    	public static Task ShowDialogAsync(this Form form, IWin32Window owner = null)
    	{
    		var tcs = new TaskCompletionSource<object>();
    		EventHandler onShown = null;
    		onShown = (sender, e) =>
    		{
    			form.Shown -= onShown;
    			tcs.TrySetResult(null);
    		};
    		form.Shown += onShown;
    		SynchronizationContext.Current.Post(_ => form.ShowDialog(owner), null);
    		return tcs.Task;
    	}
    }
