    public Task<string> GetThreadStatusAsync()
    {
        var task = new Task<string>(GetThreadStatus);
        QueueTask(task);
        return task.ContinueWith(task1 => task1.GetAwaiter().GetResult(), TaskScheduler.Default);
    }
