    static void Main(string[] args)
    {
        var json = File.ReadAllText("JsonFile1.json");
        dynamic obj = JsonConvert.DeserializeObject(json);
        var dest = new
        {
            responses = ((IEnumerable<dynamic>)obj.responses).Select(x => new
            {
                info = x.info,
                body = JsonConvert.DeserializeObject((string)x.body)
            })
        };
        var destJson = JsonConvert.SerializeObject(dest);
        File.WriteAllText("JsonFile2.json", destJson);
    }
