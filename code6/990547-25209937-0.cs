    List<string> strings = Enumerable.Range(1, 10000000).Select(x => Guid.NewGuid().ToString()).ToList();
    var sw= Stopwatch.StartNew();
                
    foreach (var str in strings) {
        if (!str.ToString().Equals(str.ToString())) {
            throw new ApplicationException("The world is ending");
        }
    }
    
    sw.Stop();
    Console.WriteLine("Took: " + sw.Elapsed.TotalMilliseconds);
    
    sw = Stopwatch.StartNew();
    foreach (var str in strings) {
        if (!str.Equals(str)) {
            throw new ApplicationException("The world is ending");
        }
    }
    sw.Stop();
    Console.WriteLine("Took: " + sw.Elapsed.TotalMilliseconds);
    Console.ReadLine();
