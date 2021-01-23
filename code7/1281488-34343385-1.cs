    Dictionary<string, string> g = new Dictionary<string, string>();
    g.Add("K", "k1");
    g.Add("L", "l1");
    
    var keys1 = g.Select(x=>String.Format("{0}=@{0}", x.Key));
    var result1 = String.Join(",", keys1);
    Console.WriteLine(result1);
    
    var keys2 = g.Select(x=>String.Format("{0}={1}", x.Key, x.Value));
    var result2 = String.Join(",", keys2);
    Console.WriteLine(result2);
