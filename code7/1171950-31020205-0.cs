    public static void ParallelForEach<T>(this IEnumerable<T> source, Func<T, Task> body)
    {
        List<Task> tasks = new List<Task>();
    
        foreach (var item in source)
        {
            tasks.Add(body(item));
        }
    
        Task.WaitAll(tasks.ToArray());
    }
