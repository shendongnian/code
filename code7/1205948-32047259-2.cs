    static async Task RunThreads(int totalThreads, int throttle)
    {
        var tasks = new List<Task>();
        for (var n = 0; n < totalThreads; n++)
        {
            var task = DoSomething(n);
            tasks.Add(task);
            if (tasks.Count == throttle)
            {
                var completed = await Task.WhenAny(tasks);
                tasks.Remove(completed);
            }
        }
        await Task.WhenAll(tasks); // all threads must complete
    }
