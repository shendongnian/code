    static Task SwitchAsync()
    {
    	if (SynchronizationContext.Current == null)
    		return Task.FromResult(false); // optimize
    
    	var tcs = new TaskCompletionSource<bool>();
    	Func<Task> yield = async () =>
    		await tcs.Task.ConfigureAwait(false);
    	var task = yield();
    	tcs.SetResult(false);
    	return task;
    }
    // ...
    await SwitchAsync().ConfigureAwait(false); 
