    System.Net.WebClient wc = new System.Net.WebClient();
    string Jayson = wc.DownloadString("http://api.urbandictionary.com/v0/define?term=api");
    object obj = JsonHelper.Deserialize(Jayson);
    Dictionary<string, object> values = 
            JsonConvert.DeserializeObject<Dictionary<string, object>>(Jayson);
    
    foreach(var entry in values)
    {
        Console.WriteLine($"{entry.Key} : {entry.Value}");
    }
