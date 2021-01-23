    Task<Task> TestTask = Task.Factory.StartNew(async () =>
    {
        // ...
        await Task.Delay(10000);
        // ...
    }, CancellationToken.None, TaskCreationOptions.None, UiScheduler);
    
    Task actualTask = TestTask.Unwrap();
