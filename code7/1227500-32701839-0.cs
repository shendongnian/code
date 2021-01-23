    static void Main(string[] args)
    {
        string jsonString1 = File.ReadAllText("sample1.json");
        string jsonString2 = File.ReadAllText("sample2.json");
        var newType = new[] { new { CreationTimeUtc = DateTime.UtcNow, LastWriteTimeUtc = DateTime.UtcNow, Name = "", Length = "", owner = "" } };
        var json1 = JsonConvert.DeserializeAnonymousType(jsonString1, newType);
        var json2 = JsonConvert.DeserializeAnonymousType(jsonString2, newType);
        var combined = json1.Union(json2);
        var results = from c in combined
                group c by c.Name into g
                select g.First(i => i.LastWriteTimeUtc == g.Max(m => m.LastWriteTimeUtc) &&
                                    i.LastWriteTimeUtc == g.Max(m => m.LastWriteTimeUtc) &&
                                    i.Length == g.Max(m => m.Length));
        foreach (var item in results)
        {
            Console.WriteLine(item);
        }
    }
