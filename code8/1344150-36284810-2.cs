    private static async Task ProcessCancellingResponseAsync(IList<object> arg1, Task<object> cancelTask)
    {
      var result = await cancelTask;
      Update(result.Response);
    }
    public object Amend(CancellationToken cancellationToken, object arg1)
    {
      ...
    }
    private static void Cancel(IList<object> arg1, object arg2)
    {
      Task<object> cancelTask = Task.Run(() => service.Amend
      (
        CancelTokenSource.Token, 
        object arg2
      );
      ProcessCancellingResponse(arg1, arg2);
    }
