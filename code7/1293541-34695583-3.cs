    /// <summary>
    /// Handles all the exceptions thrown by the <paramref name="task"/>
    /// </summary>
    /// <param name="task">The task which might throw exceptions.</param>
    /// <param name="exceptionsHandler">The handler to which every exception is passed.</param>
    /// <returns>The continuation task added to <paramref name="task"/>.</returns>
    public static Task HandleExceptions(this Task task, Action<Exception> exceptionsHandler)
    {
        return task.ContinueWith(t =>
        {
            var e = t.Exception;
    
            if (e == null) { return; }
    
            e.Flatten().Handle(ie =>
            {
                exceptionsHandler(ie);
                return true;
            });
        },
        CancellationToken.None,
        TaskContinuationOptions.ExecuteSynchronously,
        TaskScheduler.Default);
    }
