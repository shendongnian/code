What you need to do is to pass the CancellationTokenSource to your methods so when the result is empty you can call CancellationTokenSource.Cancel()
    async Task DoWorkAsync()
    {
        var cts = new CancellationTokenSource();
        var ct = cts.Token;
        var tasks = new List<Task>
        {
	    	Task.Run(() => AddToDictionary("First", () => CallFirstFunction(), cts), ct),
		    Task.Run(() => AddToDictionary("Second", () => CallSecondFunction(), cts), ct),
    		Task.Run(() => AddToDictionary("Third", () => CallThirdFunction(), cts), ct),
	    	Task.Run(() => AddToDictionary("Fourth", () => CallFourthFunction(), cts), ct),
        };
	
	    try
        {	        
	         await Task.WhenAll(tasks);	
        }
	    catch (OperationCanceledException ex)
     	{
	    }
    }
    private void AddToDictionary(string key, Func<List<int>> method, CancellationTokenSource cts)
    {
        var result = method.Invoke();
		if(!result.Any());
			cts.Cancel();
        if(!cts.IsCancellationRequested)
            dictionary.TryAdd(key, result);
    }
This example assumes that the operations you call (CallFirstFunction etc.) are not async (don't return a Task or Task<T>). Otherwise you should pass the CancellationToken to them as well and check for cancellation using ct.ThrowIfCancellationRequested
