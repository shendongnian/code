    private static void LogIfErrors(Task source)
    {
        if(source.Exception == null) return;
        source.Exception.Handle(ex =>
        {
            Log.Error("#unhandled #task #error", ex);
            return true;
        });
        return;
    }
    private void DoStuff()
    {
        // note that you cannot inline the ContinueWith() statement,
        // because it would change the value of task1 to hold your
        // continuation instead of your parent task
        var task1 = ThrowNotImplementedException();
        task1.ContinueWith(LogIfErrors, TaskContinuationOptions.OnlyOnFaulted);
        var task2 = ThrowDivideByZeroException();
        task2.ContinueWith(LogIfErrors, TaskContinuationOptions.OnlyOnFaulted);
        var firstCompleted = await Tasks.WhenAny(task1, task2).Unwrap();
    }
