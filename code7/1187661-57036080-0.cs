    static async Task<int> DelayAndReturnAsync(int val)
    {
        await Task.Delay(TimeSpan.FromSeconds(val));
        return val;
    }
    static async Task AwaitAndProcessAsync(Task<int> task)
    {
        var result = await task;
        Console.WriteLine(result);
    }
    // This method now prints "1", "2", and "3".
    static async Task ProcessTasksAsync()
    {
        // Create a sequence of tasks.
        Task<int> taskA = DelayAndReturnAsync(2);
        Task<int> taskB = DelayAndReturnAsync(3);
        Task<int> taskC = DelayAndReturnAsync(1);
        var tasks = new[] { taskA, taskB, taskC };
        var processingTasks = tasks.Select(AwaitAndProcessAsync).ToArray();
        // Await all processing to complete
        await Task.WhenAll(processingTasks);
    }
