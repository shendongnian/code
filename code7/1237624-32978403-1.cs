    Parallel.ForEach(Enumerable.Range(0, 5), i =>
    {
        Task tsk = Task.Factory.StartNew(() => DoSomething(i.ToString()));
        lstTasks.Add(tsk);
    });
