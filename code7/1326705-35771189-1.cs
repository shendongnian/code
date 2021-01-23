    public class Processor
    {
        public string Compose(BaseClass item)
        {
            if (item is DerivedClass)
            {
                var derived = (DerivedClass) item;
                return derived.Foo + derived.Bar;
            }
            return item.Foo;
        }
    }
