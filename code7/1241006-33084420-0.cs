    public async Task<int> CheckServiceAsync()
    {
       while(condition)
       {
          Thread.Sleep(1000);
          return service.GetInfo();
       }
    }
