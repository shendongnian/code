    var list = Enumerable.Range(0, 1000).ToList();
    var stopwatch = new Stopwatch();
    stopwatch.Start();
    for(var i=0; i<1000000; i++)
    {
        var c = list.GetRange(0, 100);
    }
    Console.WriteLine(stopwatch.Elapsed);
    stopwatch.Restart();
    for (var i = 0; i < 1000000; i++)
    {
         var c = list.Take(100).ToList();
    }
    Console.WriteLine(stopwatch.Elapsed);
