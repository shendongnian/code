    List<Task> TaskList = new List<Task>();
    foreach(...)
    {
        var LastTask = new Task(SomeFunction);
        LastTask.Start();
        TaskList.Add(LastTask);
    }
    
    Task.WaitAll(TaskList.ToArray());
