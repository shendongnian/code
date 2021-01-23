    public IAsyncOperation<string> DoMoreWorkAction()
    {
        return DoMoreWorkAsync().AsAsyncOperation();
    }
    internal async Task<string> DoMoreWorkAsync()
    {
        await Task.Delay(1000);
        return "Hello";
    }
    public async void Run(IBackgroundTaskInstance taskInstance)
    {
       var deferral = taskInstance.GetDeferral();
       try
       {
          await DoMoreWorkAction();
          DoAnother();
       }
       finally
       {
          deferral.Complete();
       }
    }
