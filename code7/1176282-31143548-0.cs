    // I'm hoping the real names are rather more useful - or you could use
    // Json.NET attributes to perform mapping.
    public class Foo : ISerializable
    {
        public string sTest { get; set; }
        public Bar oTest { get; set; }
    }
    public class Bar : ISerializable
    {
        public List<string> vTest { get; set; }
        public double iTest { get; set; }
    }
