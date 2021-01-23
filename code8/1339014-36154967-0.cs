    start = DateTime.Now;
    Console.Write("*Processing variables");
    Task entireTask = Task.WhenAll(tasks);
    while (await Task.WhenAny(entireTask, Task.Delay(1000)) != entireTask)
    {
      Console.Write(".");
    }
    timeDiff = DateTime.Now - start;
    Console.WriteLine("\n*Operation completed in {0} seconds.", timeDiff.TotalSeconds);
