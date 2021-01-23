    public class FooPropertiesListener : IDisposable
    {
        private readonly Foo Foo;
        public FooPropertiesListener(Foo foo)
        {
            this.Foo = foo;
            this.Foo.PropertiesListener = this;
        }
        public void Bar(string text)
        {
            //Only relevant when Text is set by the user of the class,
            //not during deserialization
        }
        public void Dispose()
        {
            Foo.PropertiesListener = null;
        }
    }
    
