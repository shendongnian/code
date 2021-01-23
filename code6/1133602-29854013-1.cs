    var list = Enumerable.Range(1, 100).ToList();
    var array = Enumerable.Range(1, 100).ToArray();
    
    int total = 0;
    
    var sw = Stopwatch.StartNew();
    for (int i = 0; i < 1000000000; i++) {
    	total ^= list[0];
    }
    Console.WriteLine("Time for list: {0}", sw.Elapsed);
    
    sw.Restart();
    for (int i = 0; i < 1000000000; i++) {
    	total ^= array[0];
    }
    Console.WriteLine("Time for list: {0}", sw.Elapsed);
