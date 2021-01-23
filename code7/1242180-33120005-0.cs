    public class Product
    {
        public string Webroot { get; set; }
        public string Version { get; set; }
        public Dictionary<string, string> Dependencies { get; set; }
        public string[] Exclude { get; set; }
    }
    [ ... ]
    static void Main()
    {
        string json = File.ReadAllText("project.json");
        Product pro = JsonConvert.DeserializeObject<Product>(json);
    
        foreach (var dependency in pro.Dependencies)
        {
            // Here you can validate each property instead of printing it ...
            Console.WriteLine("{0}: {1}", dependency.Key, dependency.Value);
        }
    
        pro.Dependencies.Add("NewProperty", "NewValue");
    
        var resultJson = JsonConvert.SerializeObject(pro, Formatting.Indented);
        Console.WriteLine(resultJson);
    }
