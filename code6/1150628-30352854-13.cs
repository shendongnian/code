    List<string> data = new List<string>();
    data.Add("01:01 A car consists of : wheels, engine, seats");
    data.Add("01:02 A bike consists of : wheels");
    data.Add("01:03 A car consists of : wheels, engine, seats, speakers");
    data.Add("01:04 A small truck consists of : wheels, engine, seats, bed");
    var elementMap = ParseData(data);
    Dictionary<string, int> displayObjects = new Dictionary<string, int>();
    foreach (KeyValuePair<string, string[]> item in elementMap)
    {
        if (displayObjects.ContainsKey(item.Key))
            displayObjects[item.Key]++;
        else
            displayObjects.Add(item.Key, 1);
        foreach (string key2 in item.Value)
        {
            if (displayObjects.ContainsKey(key2))
                displayObjects[key2]++;
            else
                displayObjects.Add(key2, 1);
        }
    }
    foreach (string key in displayObjects.Keys)
    {
        Console.WriteLine(key + ": " + displayObjects[key]);
    }
