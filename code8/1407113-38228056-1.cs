    var tasks = new List<Task>();
    
    for (int i = 0; i < n; ++i)
    {
        tasks.Add(Task.Run(action: SomeLongTask));
    }
    
    Task.WaitAll(tasks);
