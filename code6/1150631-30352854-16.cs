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
            string[] attributeValues = key2.Split(' ');
            int add = 1;
            string addValue = key2;
            if (attributeValues.Length > 1)
            {
                add = Convert.ToInt32(attributeValues[0]);
                addValue = attributeValues[1];
            }
            if (displayObjects.ContainsKey(addValue))
                displayObjects[addValue] += add;
            else
                displayObjects.Add(addValue, add);
        }
    }
    foreach (string key in displayObjects.Keys)
    {
        Console.WriteLine(key + ": " + displayObjects[key]);
    }
