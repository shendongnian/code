    class FileSystemCrawlerSO
    {
      static void Main(string[] args)
      {
        var numFolders = 0;
        Stopwatch watch = new Stopwatch();
        watch.Start();
        foreach (var dir in Directory.EnumerateDirectories(@"d:\www", "*", SearchOption.AllDirectories))
        {
          // Do something with the current folder
          // e.g. Console.WriteLine($"{dir.FullName}");
          ++numFolders;
        }
        watch.Stop();
        Console.WriteLine($"Collected {numFolders:N0} folders in {watch.ElapsedMilliseconds} milliseconds.");
        if (Debugger.IsAttached)
            Console.ReadKey();
      }
    }
