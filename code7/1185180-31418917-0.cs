    public static void HandleExceptions(this Task task)
    {
        task.ContinueWith(
            faultedTask => HandleException(faultedTask.Exception),
            TaskContinuationOptions.OnlyOnFaulted);
    }
