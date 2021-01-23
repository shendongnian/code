    Task.Factory.StartNew(() =>
    {
        // The task
    }, tokenSource.Token)
    .ContinueWith(task =>
    {
        switch (task.Status)
        {
        case TaskStatus.RanToCompletion:
            // The normal stuff
            break;
        case TaskStatus.Canceled:
            // Handle cancellation
            break;
        case TaskStatus.Faulted:
            // Handle other exceptions
            break;
        }
    });
