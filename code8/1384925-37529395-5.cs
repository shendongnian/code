    public static Task<T> FirstSuccessfulTask<T>(IEnumerable<Task<T>> tasks)
    {
        var tcs = new TaskCompletionSource<T>();
        foreach(var task in tasks)
            task.ContinueWith(t =>
                if(task.Status == TaskStatus.RanToCompletion)
                    tcs.TrySetResult(t.Result));
        return tcs.Task;
    }
