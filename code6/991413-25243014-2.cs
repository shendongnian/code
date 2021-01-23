    public IAsyncAction DoWorkAction()
    {
        return DoWorkAsync().AsAsyncAction();
    }
    internal async Task DoWorkAsync()
    {
        await Task.Delay(100);
    }
    public async void Run(IBackgroundTaskInstance taskInstance)
    {
       var deferral = taskInstance.GetDeferral();
       try
       {
          await DoWorkAction();
          DoAnother();
       }
       finally
       {
          deferral.Complete();
       }
    }
