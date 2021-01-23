    public class Processor
    {
        public string Compose(BaseClass item)
        {
            return item.Compose();
        }
    }
    public class BaseClass
    {
        public string Foo { get; set; }
        public virtual string Compose()
        {
            return Foo;
        }
    }
    public class DerivedClass : BaseClass
    {
        public string Bar { get; set; }
        public override string Compose()
        {
            return base.Compose() + Bar;
        }
    }
