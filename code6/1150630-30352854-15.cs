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
