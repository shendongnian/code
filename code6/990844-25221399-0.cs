    public static Task StartNewDelayed(int millisecondsDelay, Action action) 
    { 
        // Validate arguments 
        if (millisecondsDelay < 0) 
            throw new ArgumentOutOfRangeException("millisecondsDelay"); 
        if (action == null) throw new ArgumentNullException("action"); 
    
        // Create the task 
        var t = new Task(action); 
        // Start a timer that will trigger it 
        var timer = new Timer( 
            _ => t.Start(), null, millisecondsDelay, Timeout.Infinite); 
        t.ContinueWith(_ => timer.Dispose());
        return t; 
    }
    private static Task<T> Retry<T>(Func<T> func, int retryCount, int delay, TaskCompletionSource<T> tcs = null)
    {
        if (tcs == null)
            tcs = new TaskCompletionSource<T>();
        Task.Factory.StartNew(func).ContinueWith(_original =>
        {
            if (_original.IsFaulted)
            {
                if (retryCount == 0)
                    tcs.SetException(_original.Exception.InnerExceptions);
                else
                    Task.Factory.StartNewDelayed(delay).ContinueWith(t =>
                    {
                        Retry(func, retryCount - 1, delay,tcs);
                    });
            }
            else
                tcs.SetResult(_original.Result);
        });
        return tcs.Task;
    } 
