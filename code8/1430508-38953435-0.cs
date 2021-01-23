    public class Test
    {
        [JsonProperty("TestJsonString")]
        public string TestFieldString { get; set; }
        [JsonProperty("TestJsonInt")]
        public int TestFieldInt { get; set; }
        public int TestFieldInt2 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Test() {TestFieldInt = 1, TestFieldString = "11"};
            var testArray = data.GetType().GetProperties()
                .Where(x => x.GetCustomAttributes(true).Any(attr => attr is JsonPropertyAttribute))
                .Select(x => new []
                {
                    (x.GetCustomAttributes(typeof(JsonPropertyAttribute), true).Single() as JsonPropertyAttribute).PropertyName,
                    x.GetGetMethod().Invoke(data, null) == null ? "" : x.GetGetMethod().Invoke(data, null).ToString()
                });
            var serialized = JsonConvert.SerializeObject(testArray);
        }
    }
