    private static int counter = 1;
    private static SemaphoreSlim semaphore = new SemaphoreSlim(7);
    static void Main(string[] args)
    {
        Console.Title = "Async";
        var x = Task.Run(() => MainAsync());
        Console.ReadLine();          
    }
    private static async Task MainAsync()
    {
      while (true)
      {
        var dbData = await ...; // Imagine calling a database to get some work items to do, in this case 5 dummy items
        for (int i = 0; i < 5; i++)
        {
          var x = DoSomethingAsync(counter.ToString());
          counter++;
          Thread.Sleep(50);
        }
        Thread.Sleep(1000);
      }
    }
    private static async Task DoSomethingAsync(string jobNumber)
    {
      await semaphore.WaitAsync();
      try
      {
        try
        {
          // Simulated mostly IO work - some could be long running
          await Task.Delay(5000);
          Console.WriteLine(jobNumber);
        }
        catch (Exception ex)
        {
          LogException(ex);
        }
        Log("job {0} has completed", jobNumber);
      }
      finally
      {
        semaphore.Release();
      }
    }
