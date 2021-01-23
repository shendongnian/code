    [ToString]
    class TestClass
    {
        public int Foo { get; set; }
    
        public double Bar { get; set; }
    
        [IgnoreDuringToString]
        public string Baz { get; set; }
    }
