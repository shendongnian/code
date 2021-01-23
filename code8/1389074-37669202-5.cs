    public Task MyMethodAsync()
    {
      var tcs = new TaskCompletionSource...
      var autoReseEvent = ...
      ThreadPool.QueueUserWorkItem(new WaitCallback(() => 
                                       { 
                                         /* Work */
                                         Thread.SpinWait(1000);
                                         tcs.SetResult(...);
                                         autoResetEvent.Set();
                                        };)...;
    
      return tcs.Task;
    }
