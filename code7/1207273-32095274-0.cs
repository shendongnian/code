    var list = new List<Task<Task<string>>>();
    
    Task.WaitAll(list.ToArray());
    // now we aggregate the results
    var gatheredTasks = list.Select(t => t.Result);
    Task.WaitAll(gatheredTasks.ToArray());
    foreach (var task in gatheredTasks)
    {
        Console.WriteLine(task.Result);
    }
    
