    List<Task<...>> tasks = ... // put your 5 tasks inside this list.
 
    while(condintion)
    {
        await Task.WhenAny(tasks);
        tasks.RemoveAll(t => t.IsCompleted);
        while(tasks.Count < 5 && condintion)
        {
            Task<...> newTask = ... // run your task
            tasks.Add(newTask);
        }
    }
