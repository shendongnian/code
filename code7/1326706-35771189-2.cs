    public class Processor
    {
        public string Compose(BaseClass item)
        {
            var @class = item as DerivedClass;
            return @class?.ToString() ?? item.ToString();
        }
    }
    public class BaseClass
    {
        public string Foo { get; set; }
        public override string ToString()
        {
            return Foo;
        }
    }
    public class DerivedClass : BaseClass
    {
        public string Bar { get; set; }
        public override string ToString()
        {
            return Foo + Bar;
        }
    }
