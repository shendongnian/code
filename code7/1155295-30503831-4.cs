    // for selecting the first row which has unique "key"
    var w = Stopwatch.StartNew();
    var a = guids.GroupBy(guid => guid.Split(delimiters)[0].ToLower()).Select(grp => grp.First()).ToList();
    Console.WriteLine(w.Elapsed); // 0.65 seconds 
    
    w = Stopwatch.StartNew();
    var b = guids.AsParallel().GroupBy(guid => guid.Split(delimiters)[0].ToLower()).Select(grp => grp.First()).ToList();
    Console.WriteLine(w.Elapsed); // 0.83 seconds 
    
     
