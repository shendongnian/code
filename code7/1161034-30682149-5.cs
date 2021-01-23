    public static class Timeout
    {
        public static async Task<bool> ForAsync(Action operationWithTimeout, TimeSpan maxTime)
        {
            Contract.Requires(operationWithTimeout != null);
            Task timeoutTask = Task.Delay(TimeSpan.FromSeconds(10));
            TaskCompletionSource<Thread> copyThreadCompletionSource = new TaskCompletionSource<Thread>();
            // This will await while any of both given tasks end.
            await Task.WhenAny
            (
                timeoutTask,
                Task.Factory.StartNew
                (
                    () =>
                    {
                        // This will let main thread access this thread and force a Thread.Abort
                        // if the operation must be canceled due to a timeout
                        copyThreadCompletionSource.SetResult(Thread.CurrentThread);
                        operationWithTimeout();
                    }
                )
            );
            // Since timeoutTask was completed before wrapped File.Copy task you can 
            // consider that the operation timed out
            if (timeoutTask.Status == TaskStatus.RanToCompletion)
            {
                // Timed out!
                Thread copyThread = await copyThreadCompletionSource.Task;
                copyThread.Abort();
                return false;
            }
            else
            {
                return true;
            }             
        }
    }
