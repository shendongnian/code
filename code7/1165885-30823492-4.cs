    public Task<string> GetThreadStatusAsync()
    {
        var taskCompletionSource = new TaskCompletionSource<string>();
        var task = new Task<string>(GetThreadStatus);
        QueueTask(task);
        task.ContinueWith(task1 =>
        {
            if (task1.IsFaulted)
            {
                taskCompletionSource.SetException(task1.Exception);
            }
            else if (task1.IsCanceled)
            {
                taskCompletionSource.SetCanceled();
            }
            else
            {
                taskCompletionSource.SetResult(task1.Result);
            }
        });
        return taskCompletionSource.Task;
    }
