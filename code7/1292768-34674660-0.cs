    public class A
    {
        public string Test { get; set; } = "Test";
        public B B { get; set; } = new B();
    }
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class B
    {
        public string Foo { get; set; } = "Foo";
    }
