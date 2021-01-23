    public class Foo
    {
        public int ID { get; set; }
        
        [JsonIgnore]
        public List<Bar> bar { get; set; }
        [JsonProperty("bar")]
        private List<Bar> barSetter { set { bar = value;} }
    }
    public class Bar
    {
        public int ID { get; set; }
        
        [JsonIgnore]
        public List<Baz> baz { get; set; }
        [JsonProperty("baz")]
        private List<Baz> bazSetter { set { baz = value; } }
    }
    public class Baz
    {
        public int ID { get; set; }
    }
