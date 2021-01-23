    public static IEnumerable<Task<T>> Order<T>(this IEnumerable<Task<T>> tasks)
    {
        var taskList = tasks.ToList();
        var taskSources = new BlockingCollection<TaskCompletionSource<T>>();
        var taskSourceList = new List<TaskCompletionSource<T>>(taskList.Count);
        foreach (var task in taskList)
        {
            var newSource = new TaskCompletionSource<T>();
            taskSources.Add(newSource);
            taskSourceList.Add(newSource);
            task.ContinueWith(t =>
            {
                var source = taskSources.Take();
                if (t.IsCanceled)
                    source.TrySetCanceled();
                else if (t.IsFaulted)
                    source.TrySetException(t.Exception.InnerExceptions);
                else if (t.IsCompleted)
                    source.TrySetResult(t.Result);
            }, CancellationToken.None,
            TaskContinuationOptions.PreferFairness,
            TaskScheduler.Default);
        }
        return taskSourceList.Select(tcs => tcs.Task);
    }
