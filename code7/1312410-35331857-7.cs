    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ILogger, Logger>();
            container.AddNewExtension<LoggerExtension>();
            var a = container.Resolve<A>();
            var b = container.Resolve<B>();
            var c = container.Resolve<C>();
            var d = container.Resolve<D>();
            var x = container.Resolve<X>();
        }
    }
    public interface ILogger
    {
        Type Type { get; }
    }
    public class Logger : ILogger
    {
        private readonly Type _type;
        public Logger(Type type)
        {
            _type = type;
        }
        public Type Type { get { return _type; } }
    }
    public class A
    {
        public A(ILogger logger)
        {
            System.Diagnostics.Debug.Assert(logger.Type == typeof(A));
        }
    }
    public class B
    {
        public B(ILogger logger)
        {
            System.Diagnostics.Debug.Assert(logger.Type == typeof(B));
        }
    }
    public class C
    {
        public C(A a, D d, B b, ILogger logger)
        {
            System.Diagnostics.Debug.Assert(logger.Type == typeof(C));
        }
    }
    public class D
    {
        public D()
        {
        }
    }
    public class X
    {
        public X(Y y)
        {
        }
    }
    public class Y
    {
        public Y(ILogger logger)
        {
            System.Diagnostics.Debug.Assert(logger.Type == typeof(Y));
        }
    }
