    var str = "0, 250, 6, 5000, 10000, 15000, 20000, 25000, 70, 70, 70, 70, 70, 70, 0,";
    var timer = System.Diagnostics.Stopwatch.StartNew();
    for (var i = 0; i < 1000000; i++)
    {
        str.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
    }
    timer.Stop();
    Console.WriteLine($"Spliting took: {timer.ElapsedMilliseconds}ms");
    timer = Stopwatch.StartNew();
    for (int i = 0; i < 1000000; i++)
    {
        str.Trim(',').Split(',');
    }
    timer.Stop();
    Console.WriteLine($"Trimming then Spliting took: {timer.ElapsedMilliseconds}ms");
