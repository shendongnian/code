    public void ThreadTest()
    {
      try
      {
        var currentTasks = new List<Task>();
        SemaphoreSlim maxThread = new SemaphoreSlim(2);
        for (int i = 1; i < 5; ++i)
        {
          maxThread.Wait();
          var testTask = TestAsync(maxThread);
          currentTasks.Add(testTask);
        }
        Task.WaitAll(currentTasks.ToArray());
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.ToString());
      }
    }
    private async Task TestAsync(SemaphoreSlim maxThread)
    {
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
      await Task.Run(() => Thread.Sleep(3000));
    }
