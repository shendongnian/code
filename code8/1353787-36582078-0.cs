    class Program
    {
        class Item
        {
            [JsonProperty(PropertyName = "status")]
            public string Status { get; set; }
        }
        class Root
        {
            [JsonProperty(PropertyName = "data")]
            public Dictionary<int, Item> Data { get; set; }
        }
        static void Main(string[] args)
        {
            var root = JsonConvert.DeserializeObject<Root>(@"{ ""data"": { ""123"": { ""status"": ""Ended"" } } }");
            Console.WriteLine(root.Data[123].Status); // prints "Ended"
        }
    }
