    var tsc = new TaskCompletionSource<int>();
    
    Task.Factory.StartNew(() =>
    {
    	Thread.Sleep(10000);
    	tsc.SetResult(10);
    });
    
    var tmp = tsc.Task;
    
    TaskStatus status = tmp.Status;
    while (status != TaskStatus.RanToCompletion)
    {
    	status = tmp.Status;
    	Thread.Sleep(1000);
    	Console.WriteLine(status);
    }
