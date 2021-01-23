    Task.Factory.StartNew(() =>
    {
        // The task
    }, tokenSource.Token)
    .ContinueWith(task =>
    {
        // The normal stuff
    }, TaskContinuationOptions.OnlyOnRanToCompletion)
    .ContinueWith(task =>
    {
        // Handle cancellation
    }, TaskContinuationOptions.OnlyOnCanceled)
    .ContinueWith(task =>
    {
        // Handle other exceptions
    }, TaskContinuationOptions.OnlyOnFaulted);
