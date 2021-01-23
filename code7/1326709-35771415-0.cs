    public class BaseClass
    {
        public string Foo { get; set; }
        public virtual string GetComposeResult() { return Foo; }
    }
    public class DerivedClass : BaseClass
    {
        public string Bar { get; set; }
        public override string GetComposeResult() { return Foo + Bar; }
    }
