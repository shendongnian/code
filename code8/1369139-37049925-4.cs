    public interface IFooBar
    {
        string value { get; }
        void SetValue(string value);
        void AddFooBar(IFooBar item);
    }
    public class Bar : IFooBar
    {
        public string value { get; private set; }
        public virtual ICollection<FooBar> foos { get; private set; }
        protected Bar() : this("") { } 
        private Bar(string v) { 
            value = v;
            foos = new List<FooBar>();
        }
        public static Bar Create(string value = "") { return new Bar(value); }
        public void SetValue(string value) { this.value = value; }
        public void AddFooBar(IFooBar foo) { this.foos.Add(FooBar.Create(this.value, foo.value)); }
    }
    public class FooBar
    {
        // assuming fooValue and barValue are the keys for Foo and Bar.
        public String fooValue { get; private set; }
        public String barValue { get; private set; }
        protected FooBar() { }
        private FooBar(String foo, String bar) {
            fooValue = foo;
            barValue = bar;
        }
        public static FooBar Create(String fooValue, String barValue) { return new FooBar(fooValue, barValue); }
    }
    public class Foo : IFooBar
    {
        public string value { get; private set; }
        public virtual ICollection<FooBar> bars { get; private set; }
        protected Foo() : this("") { }
        private Foo(string v)
        {
            value = v;
            bars = new List<FooBar>();
        }
        public static Foo Create(string value = "") { return new Foo(value); }
        public void SetValue(string value) { this.value = value; }
        public void AddFooBar(IFooBar bar) { this.bars.Add(FooBar.Create(this.value, bar.value)); }
    } 
