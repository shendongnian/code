    var ids = new List<int>() {1, 2, 3, 4};
            
    TaskFactory factory = new TaskFactory();
    List<Task> tasks = new List<Task>();
    foreach (var id in ids)
    {
        tasks.Add(factory.StartNew(() => DoSomething(id))); // executes async and keeps track of the task in the list
    }
    Task.WaitAll(tasks.ToArray()); // <- blocks here until all of the async tasks have been completed
