    var cachedProcess = System.Diagnostics.Process.GetProcessesByName("application").FirstOrDefault();
    Thread.Sleep(5000); 
    while(true)
    {
        cachedProcess.Refresh();
        Console.WriteLine("Cached Thread Count: " + cachedProcess.Threads.Count);
    
        var liveReadProcess = System.Diagnostics.Process.GetProcessesByName("application").FirstOrDefault();
        Console.WriteLine("Live Thread Count: " + liveReadProcess.Threads.Count);
        Console.WriteLine("");
    
        Thread.Sleep(1000);
    }
