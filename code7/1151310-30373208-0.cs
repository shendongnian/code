    public static IAsyncResult ToBegin<T>(
        Task<T> task, AsyncCallback callback, object state)
    {
      var tcs = new TaskCompletionSource<T>(state);
      task.ContinueWith(t =>
      {
        if (t.IsFaulted) tcs.TrySetException(t.Exception.InnerExceptions)
        else if (t.IsCanceled) tcs.TrySetCanceled();
        else tcs.TrySetResult(t.Result);
        if (callback != null) callback(tcs.Task);
      }, TaskScheduler.Default);
      return tcs.Task;
    }
    public static T ToEnd<T>(IAsyncResult result)
    {
      // Original MSDN code uses Task<T>.Result
      return ((Task<T>)result).GetAwaiter().GetResult();
    }
