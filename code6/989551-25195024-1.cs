    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{ ""$"" : { ""$moniker"" : ""blob sprocket"" } }";
            Foo foo = JsonConvert.DeserializeObject<Foo>(json);
            Console.WriteLine("name from JSON = " + foo.Info.Name);
            Console.WriteLine();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new OriginalNameContractResolver();
            settings.Formatting = Formatting.Indented;
            json = JsonConvert.SerializeObject(foo, settings);
            Console.WriteLine(json);
        }
    }
    class Foo
    {
        [JsonProperty("$")]
        public Item Info { get; set; }
    }
    class Item
    {
        [JsonProperty("$moniker")]
        public string Name { get; set; }
    }
