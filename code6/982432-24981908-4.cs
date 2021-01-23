    public static class TaskExtensions
    {
        public async static Task<TResult> HandleCancellation<TResult>(
            this Task<TResult> asyncTask,
            CancellationToken cancellationToken)
        {     
            // Create another task that completes as soon as cancellation is requested.
            // http://stackoverflow.com/a/18672893/1149773
            var tcs = new TaskCompletionSource<TResult>();
            cancellationToken.Register(() =>
                tcs.TrySetCanceled(), useSynchronizationContext: false);
            var cancellationTask = tcs.Task;
            // Create a task that completes when either the async operation completes,
            // or cancellation is requested.
            var readyTask = await Task.WhenAny(asyncTask, cancellationTask);
            // In case of cancellation, register a continuation to observe any unhandled 
            // exceptions from the asynchronous operation (once it completes).
            // In .NET 4.0, unobserved task exceptions would terminate the process.
            if (readyTask == cancellationTask)
                asyncTask.ContinueWith(_ => asyncTask.Exception, 
                    TaskContinuationOptions.OnlyOnFaulted | 
                    TaskContinuationOptions.ExecuteSynchronously);
            return await readyTask;
        }
    }
