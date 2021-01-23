    public Task MyMethodAsync()
    {
      var tcs = new TaskCompletionSource<object>();
      try
      {
        AnotherOperation();
        tcs.SetResult();
      }
      catch(Exception ex)
      {
        tcs.SetException(ex);
      }
    
      return tcs.Task; 
    }
