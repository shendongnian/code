    var tasks = new List<Task)();
    // start the tasks however
    tasks.Add(Task.Run(Task1Function);
    tasks.Add(Task.Run(Task2Function);
    tasks.Add(Task.Run(Task2Function);
    while (tasks.Count > 0)
    {
       var i = Task.WaitAny(tasks.ToArray()); // yes this is ugly but an array is required
       var task = tasks[i];
       tasks.RemoveAt(i);
       ImportService.Import(task); // do you need to pass the task or the task.Result
    }
