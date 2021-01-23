    public static List<KeyValuePair<string, string[]>> ParseData(List<string> data)
    {
        Regex regex = new Regex(@"^[\d]{2}:[\d]{2} A[n]? ([a-zA-Z\s]+) consists of : ([a-zA-Z,\s0-9]+)$");
        var elementMap = new List<KeyValuePair<string, string[]>>();
        for (int i = 0; i < data.Count; i++)
        {
            var match = regex.Match(data[i]);
            var attributes = match.Groups[2].Value.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            elementMap.Add(new KeyValuePair<string, string[]>(match.Groups[1].Value, attributes));
        }
        return elementMap;
    }
    public static Dictionary<string, int> GetIndexedData(List<KeyValuePair<string, string[]>> data)
    {
        Dictionary<string, int> displayObjects = new Dictionary<string, int>();
        foreach (KeyValuePair<string, string[]> item in data)
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
                else if (addValue.Substring(0, 3) == "an ")
                    addValue = addValue.Substring(3);
                if (displayObjects.ContainsKey(addValue))
                    displayObjects[addValue] += add;
                else
                    displayObjects.Add(addValue, add);
            }
        }
        return displayObjects;
    }
