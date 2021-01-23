    class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterInstance(new FooProvider(new Foo("a")))
                   .As<FooProvider>();
            builder.Register(c => c.Resolve<FooProvider>().Value)
                   .ExternallyOwned()
                   .Keyed<Foo>(1);
            IContainer container = builder.Build();
            using (ILifetimeScope scope = container.BeginLifetimeScope())
            {
                Do(scope);
            }
            using (ILifetimeScope scope = container.BeginLifetimeScope())
            {
                IComponentContext context = scope.Resolve<IComponentContext>();
                container.Resolve<FooProvider>().Value = new Foo("b");
                Do(scope);
            }
            using (ILifetimeScope scope = container.BeginLifetimeScope())
            {
                Do(scope);
            }
        }
        static void Do(ILifetimeScope scope)
        {
            IIndex<Int32, Foo> index = scope.Resolve<IIndex<Int32, Foo>>();
            Foo foo = index[1];
            Console.WriteLine(foo.Value);
        }
    }
    public class FooProvider 
    {
        public FooProvider(Foo value)
        {
            this._value = value;
        }
        private Foo _value;
        public Foo Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }
    public class Foo 
    {
        public Foo(String value)
        {
            this._value = value;
        }
        private readonly String _value;
        public String Value
        {
            get
            {
                return this._value;
            }
        }
    }
