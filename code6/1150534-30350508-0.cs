    stopwatch.Start();
    var s = "";
    for (int i = 0; i < 100000; i++)
    {
        s = "." + s;
    }
    stopwatch.Stop();
    Console.WriteLine(stopwatch.ElapsedMilliseconds);
    stopwatch.Restart();
    var s2 = new StringBuilder();
    for (int i = 0; i < 100000; i++)
    {
         s2.Insert(0, ".");
    }
    stopwatch.Stop();
    Console.WriteLine(stopwatch.ElapsedMilliseconds);
