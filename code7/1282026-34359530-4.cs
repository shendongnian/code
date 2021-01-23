    cancellationTokenSource.Cancel();
    var task = Task.Run(() => { }, cancellationTokenSource.Token);
    try
    {
        await task; 
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
        Console.WriteLine($"Task.IsCanceled: {task.IsCanceled}");
        Console.WriteLine($"Task.IsFaulted: {task.IsFaulted}");
        Console.WriteLine($"Task.Exception: {((task.Exception == null) ? "null" : task.Exception.ToString())}");
    }
