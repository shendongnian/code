    static void Main(string[] args)
    {
      ids = Enumerable.Range(1, 10).ToArray();
      try
      {
        tasks = ids.Select(id => MyTaks(id)).ToArray();
        Task.WaitAll(tasks);
      }
      catch (Exception exception)
      {
        Console.WriteLine("Exception in Main::\nMessage: " + exception.Message +
                    "StackTrace: " + exception.StackTrace +
                    "InnerException: " + exception.InnerException);
      }
      lock (threadsExecuted)
        Console.WriteLine("\n\nThreads executed: " + string.Join(", ", threadsExecuted.OrderBy(id => id).ToArray()));
      Console.WriteLine("\n\n\nExit..");
      Console.Read();
    }
    private static async Task MyTaks(int id)
    {
      var delay = delays[id - 1] * 1000;
      Console.WriteLine("Task id #" + id + " started with delay " + delay + " seconds.");
      CancellationToken cToken = tokenSource.Token;
      // Production code would use `await httpClient.GetAsync(url, token)` here.
      await Task.Delay(delay, cToken);
      if (id == 5) //Fail
      {
        Console.WriteLine("Cancelling..");
        tokenSource.Cancel();
        throw new Exception("Thread id #" + id + " failed.");
      }
      Console.WriteLine("Thread id #" + id + " executed.");
      lock (threadsExecuted)
        threadsExecuted.Add(id);
    }
