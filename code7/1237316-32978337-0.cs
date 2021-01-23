    static void Main(string[] args)
    {
      MainAsync().Wait();
    }
    static CancellationTokenSource mycts = new CancellationTokenSource();
    static async Task MainAsync()
    {
      try
      {
        var task1 = CancelAfterSuccessfulCompletionAsync(
            Task.Run(() => SomeWorkThatCanThrowException()));
        var task2 = CancelAfterSuccessfulCompletionAsync(
            Task.Run(() => OtherWorkThatCanThrowException()));
        var consoleTask = CancelAfterSuccessfulCompletionAsync(
            Task.Run(() => MonitorConsole()));
        await Task.WhenAll(task1, task2, consoleTask);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }
    static void OtherWorkThatCanThrowException()
    {
      Thread.Sleep(5000);
      mycts.Token.ThrowIfCancellationRequested();
      throw new InvalidOperationException("test");
    }
    static void SomeWorkThatCanThrowException()
    {
      Thread.Sleep(1000);
      mycts.Token.ThrowIfCancellationRequested();
      throw new InvalidOperationException("test");
    }
    static void MonitorConsole()
    {
      Console.WriteLine("Press Enter to exit");
      Console.ReadLine();
    }
    static async Task CancelAfterSuccessfulCompletionAsync(Task task)
    {
      await task;
      mycts.Cancel();
    }
