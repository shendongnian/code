    List<string> data = new List<string>();
    data.Add("01:01 A car consists of : wheels, engine, seats, 2 screws, a cotton lamp");
    data.Add("01:02 A bike consists of : wheels");
    data.Add("01:03 A car consists of : wheels, engine, seats, speakers, 5 screws, an indicator light");
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
            int c = 0;
            if (attributeValues.Length > 1 && int.TryParse(attributeValues[0], out c))
            {
                add = c;
                addValue = attributeValues[1];
            }
            if (addValue.Substring(0, 2) == "a ")
                addValue = addValue.Substring(2);
            else if(addValue.Substring(0, 3) == "an ")
                addValue = addValue.Substring(3);
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
