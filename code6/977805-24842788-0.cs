    Thread.CurrentThread.Priority = ThreadPriority.Highest;
    Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
    
    var ticks = 0L;
    var iteration = 0D;
    var timer = new Stopwatch();
    
    do
    {
    	iteration++;
    	timer.Restart();
    	Thread.Sleep(1);
    	timer.Stop();
    	ticks += timer.Elapsed.Ticks;
    
    	if (Console.KeyAvailable) { if (Console.ReadKey(true).Key == ConsoleKey.Escape) { break; } }
    
    	Console.WriteLine("Elapsed (ms): Last Iteration = {0:N2}, Average = {1:N2}.", timer.Elapsed.TotalMilliseconds, TimeSpan.FromTicks((long) (ticks / iteration)).TotalMilliseconds);
    }
    while (true);
    
    Console.WriteLine();
    Console.WriteLine();
    Console.Write("Press any key to continue...");
    Console.ReadKey(true);
