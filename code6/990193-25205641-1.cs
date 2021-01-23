    public class TestClass
    {
        public Gender Gender { get; set; }
        [JsonConverter(typeof(DictionaryConverter))]
        public IDictionary<Gender, int> Dictionary { get; set; }
        public TestClass()
        {
            this.Dictionary = new Dictionary<Gender, int>();
        }
    }
