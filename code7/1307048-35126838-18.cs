    public static async Task RunWorkers()
    {
        Task[] tasks = new Task[6];
        for (int i = 0; i < 6; ++i)
            tasks[i] = JobDispatcher(1000 + i*1000, "task " + i);
        await Task.WhenAll(tasks);
    }
