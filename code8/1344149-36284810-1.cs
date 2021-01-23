    private static void ProcessCancellingResponse(IList<object> arg1, Task<object> cancelTask)
    {
      Action<Task> continuation = task => { Update(Task.Result.Response); };
      var token = CancelTokenSource.Token;
      var options = TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnRanToCompletion;
      var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
      cancelTask.ContinueWith(continuation, token, options, scheduler);
    }
