    Task ProcessWriteMultAsync(CancellationTokenSource source)
    {
      // ...
    }
    
    var cts = new CancellationTokenSource();
    await ProcessWriteMultAsync(cts.Token);
    if(Console.ReadKey().Key==System.ConsoleKey.Escape)
               cts.Cancell();
