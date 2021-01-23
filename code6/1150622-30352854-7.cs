    List<string> data = new List<string>();
    data.Add("01:01 A car consists of : wheels, engine, seats");
    data.Add("01:02 A bike consists of : wheels");
    data.Add("01:03 A small truck consists of : wheels, engine, seats, bed");
    var elementMap = ParseData(data);
            
    foreach (string key in elementMap.Keys)
    {
        Console.WriteLine(key);
        Console.WriteLine("    " + string.Join(", ", elementMap[key]));
    }
