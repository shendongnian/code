    List<Task> tasks= new List<Task>();
    if (condition1)
    {
        tasks.Add(Task.Factory.StartNew(() => MyMethod1()));
    }
    if (condition2)
    { 
        tasks.Add(Task.Factory.StartNew(() => MyMethod2()));
    }
    await Task.WhenAll(tasks);
