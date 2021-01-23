    static SemaphoreSlim throttle = new SemaphoreSlim(50);
    static async Task ProcessAsync(Item item)
    {
      await throttle.WaitAsync();
      try
      {
        ... // Original process(item) code
      }
      finally
      {
        throttle.Release();
      }
    }
