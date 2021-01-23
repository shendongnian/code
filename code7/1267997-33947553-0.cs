    public static async Task RunParallelAsync<T>(this IEnumerable<T> items, Func<T, Task> asyncAction, int maxParallel)
    {
        var tasks = new List<Task>();
    
        foreach (var item in items)
        {
            tasks.Add(asyncAction(item));
    
            var notCompleted = tasks.Where(t => !t.IsCompleted).ToList();
    
            if (notCompleted.Count >= maxParallel)
                await Task.WhenAny(notCompleted);
        }
    
        await Task.WhenAll(tasks);
    }
