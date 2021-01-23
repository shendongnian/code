    Guid id = Guid.NewGuid();
    
    Task task = null;
    var entry = new TaskEntry();
    if (tasks.TryAdd(id, entry))
    {
        entry.Task = Get();
    
        // Notice this line of code:
        task = entry.Task.ContinueWith(Complete);
    }
    
    if (task != null)
    {
        task.Wait();
    }
    
    Console.WriteLine("end test");
