    // I'm hoping the real names are rather more useful - or you could use
    // Json.NET attributes to perform mapping.
    [Serializable]
    public class Foo
    {
        public string sTest { get; set; }
        public Bar oTest { get; set; }
    }
    [Serializable]
    public class Bar
    {
        public List<string> vTest { get; set; }
        public double iTest { get; set; }
    }
