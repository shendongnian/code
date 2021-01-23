    public interface ISomeClass<T> where T : class
    {
        Int32 Count { get; }
    }
    public class SomeClass<T> : ISomeClass<T> where T : class
    {
        private readonly IEnumerable<ITestInterface<T>> _testInterfaces;
        public SomeClass(IEnumerable<ITestInterface<T>> testInterfaces)
        {
            _testInterfaces = testInterfaces;
        }
        public Int32 Count
        {
            get
            {
                return this._testInterfaces.Count();
            }
        }
    }
    public interface ITestInterface<T> { }
    public class A { }
    public class B { }
    public class TestImplementationA : ITestInterface<A> { }
    public class TestImplementationB : ITestInterface<B> { }
    class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<TestImplementationA>()
                    .As<ITestInterface<A>>();
            builder.RegisterType<TestImplementationB>()
                   .As<ITestInterface<B>>();
            builder.RegisterGeneric(typeof(SomeClass<>))
                   .As(typeof(ISomeClass<>));
            IContainer container = builder.Build();
            var x = container.Resolve<ISomeClass<A>>();
            Console.WriteLine(x.Count);
        }
    }
