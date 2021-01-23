        public class Program
    {
        public static void Main(string[] args)
        {
            string deser = "{\n  \"data\": [\n    {\n      \"listid\": \"\",\n      \"name\": \"\"\n    }\n  ]\n}";
            var obj = JsonConvert.DeserializeObject<MyCollection>(deser);
        }
    }
    public class MyType
    {
        [JsonProperty("listid")]
        public string ListId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class MyCollection
    {
        [JsonProperty("data")]
        public List<MyType> Data { get; set; }
    }
