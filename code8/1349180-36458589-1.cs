    ContainerBuilder builder = new ContainerBuilder();
    builder.RegisterType<EventOne>().As<IEvent>();
    builder.RegisterType<EventTwo>().As<IEvent>();
    builder.RegisterType<EventThree>().As<IEvent>();
    builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            .AsClosedTypesOf(typeof(IHandleEvent<>));
    builder.RegisterSource(new CovariantHandleEventRegistrationSource());
    IContainer container = builder.Build();
    var x = container.Resolve<IEnumerable<IHandleEvent<IEvent>>>();
