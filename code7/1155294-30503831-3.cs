       var guids = Enumerable.Range(1, 1600000).Select(_ => Guid.NewGuid().ToString().ToUpper()).ToList();
    guids = guids.Select(g => Regex.Replace(g, @"^([0-9A-F])[^\-]+", "$1$1$1$1")).ToList();
    var delimiters = "-".ToCharArray();
        var delimiters = "-".ToCharArray();
    
    var w = Stopwatch.StartNew();
    var x = guids.Select(guid => guid.Split(delimiters)[0].ToLower()).Distinct().ToList();
    Console.WriteLine(w.Elapsed); // 1.80 seconds 
    
    w = Stopwatch.StartNew();
    var y = guids.Select(guid => guid.Split(delimiters)[0].ToLower()).AsParallel().Distinct().ToList();
    Console.WriteLine(w.Elapsed); // 1.67 seconds 
    
    w = Stopwatch.StartNew();
    var z = guids.AsParallel().Select(guid => guid.Split(delimiters)[0].ToLower()).Distinct().ToList();
    Console.WriteLine(w.Elapsed); // 0.75 seconds
