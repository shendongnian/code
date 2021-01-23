    var tasks = new List<Task<ExecutorResult>>();
    foreach (var executor in executors)
    {
        tasks.Add(((Func<IExecutor, Task<ExecutorResult>>)(
            async (e) => new ExecutorResult
            {
                ExecutorName = e.Name,
                Result = await e.Execute()
            }))(executor));
    }
    var results = Task.WhenAll(tasks);
