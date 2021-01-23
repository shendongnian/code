    var cts = new CancellationTokenSource();
    cts.Cancel();
    var token = cts.token;
    
    var task1 = new Task(() => token.ThrowIfCancellationRequested());
    task1.Start();
    task1.Wait(); // task in Faulted state
    
    var task2 = new Task(() => token.ThrowIfCancellationRequested(), token);
    task2.Start();
    task2.Wait(); // task in Cancelled state
    
    var task3 = (new Func<Task>(async() => token.ThrowIfCancellationRequested()))();
    task3.Wait(); // task in Cancelled state
