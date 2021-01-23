    public async Task TestAsync()
    {
      try
      {
        var currentTasks = new List<Task>();
        SemaphoreSlim throttle = new SemaphoreSlim(2); // Not "maxThread" since we're not dealing with threads anymore
        for (int i = 1; i < 5; ++i)
        {
          var testTask = TestAsync(throttle);
          currentTasks.Add(testTask);
        }
        await Task.WhenAll(currentTasks);
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.ToString());
      }
    }
    private async Task TestAsync(SemaphoreSlim throttle)
    {
      await throttle.WaitAsync();
      try
      {
        await FaultyAsync();
      }
      finally
      {
        maxThread.Release();
      }
    }
    private async Task FaultyAsync()
    {
      throw new Exception("Never reach the awaiter");
      await Task.Delay(3000); // Naturally asynchronous operation
    }
