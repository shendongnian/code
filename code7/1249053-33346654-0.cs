    public async Task RunAsync()
    {
      var tasks = new List<Task>();
      var count = 500;
      for (var i = 0; i < count; ++i)
        tasks.Add(CallMethodAsync(i));
      await Task.WhenAll(tasks);
    }
    private async Task CallMethodAsync(int i)
    {
      try
      {
        await AsyncMethod(i);
      }
      catch (Exception ex)
      {
        Debug.WriteLine("ERROR: "+ ex.Message, ex);
        throw; // TODO: Decide if this is the behavior you want.
      }
    }
