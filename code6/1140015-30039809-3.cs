    private static async Task MyAsyncMethod()
    {
      MyContext.CurrentContext = Guid.NewGuid();
      Debug.WriteLine("Log message: {0}", MyContext.CurrentContext);
      await Task.Delay(1000);
      Debug.WriteLine("Log message: {0}", MyContext.CurrentContext);
      await Task.Delay(1000);
      Debug.WriteLine("Log message: {0}", MyContext.CurrentContext);
    }
