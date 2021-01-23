    string json = "{\"`LCA0009\": [], \"`LCA0001\": {\"23225007190002\": \"1\",\"23249206670003\": \"1\",\"01365100070018\": \"5\"},\"`LCA0003\": {\"23331406670018\": \"1\",\"24942506670004\": \"1\"},\"`LCA0005\": {\"01365100070018\": \"19\"}}";
    // Convert it
    var root = JsonConvert.DeserializeObject(json);
    Dictionary<string, Dictionary<string,int>> results = new Dictionary<string, Dictionary<string,int>>();
    foreach (var entry in (JObject)root)
    {
        var dict = new Dictionary<string,int>();
        if (!(entry.Value is JArray))
        {
            foreach (var subentry in (JObject)entry.Value)
            {
                int v;
                if (int.TryParse(((JValue)subentry.Value).ToString(), out v))
                {
                    dict.Add(subentry.Key, v);
                }
            }
        }
        results.Add(entry.Key, dict);
    }
    
    // Results:
    foreach (var name in results.Keys)
    {
        var entry = results[name];
        Console.WriteLine(name + ":");
        foreach (var entryKey in entry.Keys)
        {
            Console.WriteLine("- " + entryKey + ": " + entry[entryKey]);
        }
    }
