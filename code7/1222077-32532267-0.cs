    var tasks = new List<Task>();
    for (var i = 0; i < Iterations; i++)
    {
        Task t = MyAwaitableMethod(DelayInMilliseconds);
        tasks.Add(t);
    }
    
    await Task.WhenAll(tasks);
