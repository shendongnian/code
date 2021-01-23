    internal class CompositionRoot
    {
        public static ILifetimeScope CreateScope()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MyService>().As<IMyService>().SingleInstance();
            // other things you want to register
            return builder.Build();
        }
    }
