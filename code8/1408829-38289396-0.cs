    public static Task<Task<T>> WhenFirst<T>(IEnumerable<Task<T>> tasks, Func<Task<T>, bool> predicate)
    {
        if (tasks == null) throw new ArgumentNullException(nameof(tasks));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));
        var tasksArray = (tasks as IReadOnlyList<Task<T>>) ?? tasks.ToArray();
        if (tasksArray.Count == 0) throw new ArgumentException("Empty task list", nameof(tasks));
        if (tasksArray.Any(t => t == null)) throw new ArgumentException("Tasks contains a null reference", nameof(tasks));
        var tcs = new TaskCompletionSource<Task<T>>();
        var count = tasksArray.Count;
        
        Action<Task<T>> continuation = t =>
            {
                if (predicate(t))
                {
                    tcs.TrySetResult(t);
                }
                if (Interlocked.Decrement(ref count) == 0)
                {
                    tcs.TrySetResult(null);
                }
            };
            
        foreach (var task in tasksArray)
        {
            task.ContinueWith(continuation);
        }
        
        return tcs.Task;
    }
