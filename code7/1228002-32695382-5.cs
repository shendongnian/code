    foreach(IEnumerable<string> batch in str.Partitition(5))
    {
      Stopwatch timer = Stopwatch.StartNew();
      
      Parallel.ForEach(
        batch, 
        new ParallelOptions { MaxDegreeOfParallelism = 5 },
        (value, pls, index) =>
        {
          Console.WriteLine(value);// simulating method call
        });
        
      timer.Stop();
      int remainingMilliseconds = 5000 - timer.ElapsedMilliseconds;
      if(remainingMilliseconds > 0)
      {
        // replace with something more precise/thread friendly as needed.
        Thread.Sleep(remainingMilliseconds);
      }
    }
