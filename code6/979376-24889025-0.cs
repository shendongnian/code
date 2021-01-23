    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""items"" : ""1"",
                ""itemdetails"": 
                [
                    {
                        ""id"" : ""5"",
                        ""name"" : ""something""
                    }
                ]
            }";
            Parent parent = JsonConvert.DeserializeObject<Parent>(json);
            foreach (Item item in parent.Items)
            {
                Console.WriteLine(item.Name + " (" + item.Id + ")");
            }
        }
    }
    class Parent
    {
        [JsonProperty("itemdetails")]
        public IEnumerable<Item> Items { get; set; }
    }
    class Item
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
