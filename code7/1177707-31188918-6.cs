    public class Test
    {
        public Blabla blabla { get; set; }
    }
    public class Blabla
    {
        public string _score { get; set; }
        public string _ref { get; set; }
        [JsonConverter(typeof(FooConverter))]
        public Foo[] foo { get; set; }
    }
    public class Foo
    {
        public string _colour { get; set; }
        public string _ref { get; set; }
    }
