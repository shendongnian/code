     public static Task RetryAsync(Func<bool> retryFunc, CancellationToken cancellationToken, int retryInterval)
        {
            var tcs = new TaskCompletionSource<object>();
            var timer = new Timer((state) =>
            {
                var taskCompletionSource = (TaskCompletionSource<object>)state;
                if (!taskCompletionSource.Task.IsCompleted)
                {
                    try
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            taskCompletionSource.SetException(new TaskCanceledException("RetryAsync cancelled"));
                        }
                        else if (retryFunc())
                        {
                            taskCompletionSource.SetResult(null);
                        }
                    }
                    catch (Exception ex)
                    {
                        taskCompletionSource.SetException(ex);
                    }
                }
            }, tcs, 0, retryInterval);
            // Once the task is complete, dispose of the timer so it doesn't keep firing.
            tcs.Task.ContinueWith(t => timer.Dispose(), 
                                  CancellationToken.None, 
                                  TaskContinuationOptions.ExecuteSynchronously, 
                                  TaskScheduler.Default);
            return tcs.Task;
        }
        
