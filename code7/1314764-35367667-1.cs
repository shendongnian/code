    Task task = ...
    task.ContinueWith(
        _ => MyExceptionHandler.Handle(_.Exception),
        TaskContinuationOptions.OnlyOnFaulted);
    task.ContinueWith(_ =>
    {
        if (_.Exception)
        {
            // ...
        }
    });
