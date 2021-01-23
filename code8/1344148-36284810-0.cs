    private static void ProcessCancellingResponse(IList<object> arg1, Task<object> cancelTask)
    {
      cancelTask.ContinueWith
      (
        task =>
        {
            Update(task.Result.Response);
        },
        CancelTokenSource.Token,
        TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnRanToCompletion,
        TaskScheduler.FromCurrentSynchronizationContext()
      );
    }
