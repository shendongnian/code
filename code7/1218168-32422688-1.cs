    ContainerBuilder builder = new ContainerBuilder();
    builder.RegisterType<A1>().As<IA>();
    builder.RegisterType<A1>().As<IA>();
    builder.RegisterType<A2>().As<IA>();
    builder.RegisterSource(new CustomEnumerableRegistrationSource());
    IContainer container = builder.Build();
    IEnumerable<IA> services = container.Resolve<IEnumerable<IA>>();
    Console.WriteLine(services.Count());
