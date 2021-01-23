    [JsonConverter(typeof(NoFormattingConverter))]
    public class NestedClass
    {
        public string[] Values { get; set; }
    }
    public class TestClass
    {
        public string AValue { get; set; }
        public NestedClass NestedClass { get; set; }
        public string ZValue { get; set; }
        public static void Test()
        {
            var test = new TestClass { AValue = "A Value", NestedClass = new NestedClass { Values = new[] { "one", "two", "three" } }, ZValue = "Z Value" };
            Debug.WriteLine(JsonConvert.SerializeObject(test, Formatting.Indented));
        }
    }
