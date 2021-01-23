    Task t = new Task(async () => await Get(), cancel.Token);
    
    // NOTE: t2 is a new Task returned from ContinueWith
    Task t2 = t.ContinueWith(Complete);
    
    if (tasks.TryAdd(id, t))
    {
        t.Start();
    }
    else
    {
    }
    
    // NOTE: Waiting on t2, NOT t
    t2.Wait();
    
    Console.WriteLine("end test");
