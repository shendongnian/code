    var set1 = new HashSet<Tuple<string, string>>(Enumerable.Range(0, 1000000).Select(x => Tuple.Create("a" + x, "b" + x)));
    var set2 = new HashSet<Tuple<string, string>>(Enumerable.Range(500000, 1000000).Select(x => Tuple.Create("a" + x, "b" + x)));
    var sw = Stopwatch.StartNew();
    var result =  set2.Except(set1).ToList();
    Console.WriteLine(sw.Elapsed);
