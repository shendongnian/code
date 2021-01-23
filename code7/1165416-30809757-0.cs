    static void Main(string[] args)
    {
        // original list of data
        var list = new List<Tuple<string, string>> { };
        list.Add(new Tuple<string, string>("a", "b"));
        list.Add(new Tuple<string, string>("b", "a"));
        // dictionary to hold unique tuples
        var dict = new Dictionary<string, Tuple<string, string>>();
        foreach (var item in list)
        {
            var key1 = string.Concat(item.Item1, ":", item.Item2);
            var key2 = string.Concat(item.Item2, ":", item.Item1);
            // if dict doesnt contain tuple, add it.
            if (!dict.ContainsKey(key1) && !dict.ContainsKey(key2))
                dict.Add(key1, item);
        }
        // print unique tuples
        foreach (var item in dict)
        {
            var tuple = item.Value;
            Console.WriteLine(string.Concat(tuple.Item1, ":", tuple.Item2));
        }
        Console.ReadKey();
    }
