    public static async Task IgnoreCancelAndFailure<T>(this Task<T> task, Action<T> resultProcessor) 
    {
        task.ContinueWith(t => resultProcessor(t.Result),
            TaskContinuationOptions.OnlyOnRanToCompletion);
    }
    async void Foo()
    {
        GetMyTask().IgnoreCancelAndFailure(ProcessResult);
    }
