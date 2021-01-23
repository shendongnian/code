    Stopwatch sw= new Stopwatch();
    sw.Start();
    // your methods to be measured
    sw.Stop();
    TimeSpan ts = stopWatch.Elapsed;
    
    //Format 
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        ts.Hours, ts.Minutes, ts.Seconds,
        ts.Milliseconds / 10);
    Console.WriteLine("RunTime " + elapsedTime);
