    public static Task<T> GetFirstResult<T>(
        ICollection<Func<CancellationToken, Task<T>>> taskFactories, 
        Predicate<T> predicate) where T : class
    {
        var tcs = new TaskCompletionSource<T>();
        var cts = new CancellationTokenSource();
        
        int completedCount = 0;
        // in case you have a lot of tasks you might need to throttle them 
        //(e.g. so you don't try to send 99999999 requests at the same time)
        // see: http://stackoverflow.com/a/25877042/67824
        foreach (var taskFactory in taskFactories)
        {
            taskFactory(cts.Token).ContinueWith(t => 
            {
                if (t.Exception != null)
                {
                    Console.WriteLine($"Task completed with exception: {t.Exception}");
                }
                else if (predicate(t.Result))
                {
                    cts.Cancel();
                    tcs.TrySetResult(t.Result);
                }
                
                if (Interlocked.Increment(ref completedCount) == taskFactories.Count)
                {
                    tcs.SetException(new InvalidOperationException("All tasks failed"));
                }
                
            }, cts.Token);
        }
        
        return tcs.Task;
    }
