    private static int counter = 1;
    static void Main(string[] args)
    {
        Console.Title = "Async";
        var x = Task.Run(() => MainAsync());
        Console.ReadLine();          
    }
    private static async Task MainAsync()
    {
      var blockOptions = new ExecutionDataflowBlockOptions
      {
        MaxDegreeOfParallelism = 7
      };
      var block = new ActionBlock<string>(DoSomethingAsync, blockOptions);
      while (true)
      {
        var dbData = await ...; // Imagine calling a database to get some work items to do, in this case 5 dummy items
        for (int i = 0; i < 5; i++)
        {
          block.Post(counter.ToString());
          counter++;
          Thread.Sleep(50);
        }
        Thread.Sleep(1000);
      }
    }
    private static async Task DoSomethingAsync(string jobNumber)
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
