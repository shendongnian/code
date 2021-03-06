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
        public C(A a, B b, ILogger logger)
        {
            System.Diagnostics.Debug.Assert(logger.Type == typeof(C));
        }
    }
