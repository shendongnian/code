    public class Test
    {
        [Fact]
        public void Foo()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Service>().ToSelf();
            kernel.Bind<Logger>().ToSelf()
                .OnActivation((ctx, logger) =>
                    logger.Initalize(ctx.Request.Target.Member.DeclaringType));
            var service = kernel.Get<Service>();
            service.Logger.RootService.Should().Be(typeof(Service));
        }
    }
    public class Logger
    {
        public Type RootService { get; private set; }
        public void Initalize(Type rootService)
        {
            this.RootService = rootService;
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
