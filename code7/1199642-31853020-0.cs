    static void Main(string[] args)
    {
        Rootobject root = new Rootobject();
        root.must = new Must[2];
        root.must[0] = new Must() { match = new Match() { pname = "TEXT_MATCH" } };
        root.must[1] = new Must() { _bool = new Bool() { rname = "TEXT_BOOL" } };
        string result = Newtonsoft.Json.JsonConvert.SerializeObject(root, 
            Newtonsoft.Json.Formatting.Indented, 
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        Console.WriteLine(result);
    }
