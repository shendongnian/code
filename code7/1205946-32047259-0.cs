    static async Task RunThreads(int totalThreads, int throttle)
    {
        var tasks = new List<Task>();
        for (var n = 0; n < totalThreads; n++)
        {
            var task = DoSomething(n);
            tasks.Add(task);
            if (tasks.Count == throttle)
            {
                await Task.WhenAll(tasks);
                tasks.Clear();
            }
        }
        await Task.WhenAll(tasks); // wait for remaining
    }
