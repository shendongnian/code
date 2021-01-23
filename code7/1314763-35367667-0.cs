    Task task = ...
    task.ContinueWith(_ => MyExceptionHandler.Handle(_.Exception));
    task.ContinueWith(_ =>
    {
        if (_.Exception)
        {
            // ...
        }
    });
