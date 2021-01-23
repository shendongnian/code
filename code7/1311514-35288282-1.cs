    public class Test
    {
        [Fact]
        public void Foo()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Service>().ToSelf();
            kernel.Bind<Logger>().ToSelf()
                .WithConstructorArgument(
                    typeof(Type),
                    ctx => ctx.Request.Target.Member.DeclaringType);
            var service = kernel.Get<Service>();
            service.Logger.RootService.Should().Be(typeof(Service));
        }
    }
    public class Logger
    {
        private readonly Type _rootService;
        
        public Logger(Type rootService)
        {
            _rootService = rootService;
        }
        public Type RootService
        {
            get { return _rootService; }
        }
    }
    public class Service
    {
        public Logger Logger { get; private set; }
        public Service(Logger logger)
        {
            Logger = logger;
        }
    }
