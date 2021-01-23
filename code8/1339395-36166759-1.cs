    class FooA
    {
        [JsonIncludeAtDepthAttribute]
        public int SomeValueA { get; set; }
        public int SomeValueB { get; set; }
        public int SomeValueC { get; set; }
    }
    class FooB
    {
        public FooA FooA { get; set; }
    }
