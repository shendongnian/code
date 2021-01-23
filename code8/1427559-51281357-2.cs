    var taskScheduler = new ThrottledTaskScheduler(
        TaskScheduler.Default,
        128,
        TaskCreationOptions.LongRunning | TaskCreationOptions.HideScheduler,
        logger
        );
    var taskFactory = new TaskFactory(taskScheduler);
    for (var i = 0; i < 30000; i++)
    {
        tasks.Add(taskFactory.StartNew(DoOneThing))
    }
    Task.WaitAll(tasks.ToArray());
