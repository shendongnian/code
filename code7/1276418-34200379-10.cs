    public static async Task<T> DefaultIfFaulted<T>(this Task<T> task)
    {
        // Await completion regardless of resulting Status (alternatively you can use try/catch).
        await task
            .ContinueWith(_ => { }, TaskContinuationOptions.ExecuteSynchronously)
            .ConfigureAwait(false);
        return task.Status != TaskStatus.Faulted
            // This await preserves the task's behaviour
            // in all cases other than faulted.
            ? await task.ConfigureAwait(continueOnCapturedContext: false)
            : default(T);
    }
