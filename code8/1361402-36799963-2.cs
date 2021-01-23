    for (int i = 0; i < taskList.Count; i++)
    {
        var task = taskList[i];
        var newSource = new TaskCompletionSource<Tuple<T, int>>();
        taskSources.Add(newSource);
        taskSourceList.Add(newSource);
        int index = i; // <- add this variable.
        task.ContinueWith(t =>
        {
            var source = taskSources.Take();
            if (t.IsCanceled)
                source.TrySetCanceled();
            else if (t.IsFaulted)
                source.TrySetException(t.Exception.InnerExceptions);
            else if (t.IsCompleted)
                source.TrySetResult(new Tuple<T, int>(t.Result, index));
        }, CancellationToken.None, TaskContinuationOptions.PreferFairness, TaskScheduler.Default);
    }
