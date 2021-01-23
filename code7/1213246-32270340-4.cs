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
    public async Task DoSomethingAsync()
    {
        // We are on a thread that has a SynchronizationContext here.
        await SwitchAsync().ConfigureAwait(false); 
        // We're on a thread pool thread without a SynchronizationContext 
        await DoSomethingElseAsync(); // no need for ConfigureAwait(false) here
        // ...       
    }
