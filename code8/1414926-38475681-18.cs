    container.RegisterType<IWriter, DBWriter>("DB");
    container.RegisterType<IWriter, FileWriter>("FILE");
    container.RegisterType<IFactory, Factory>(
        new ContainerControlledLifetimeManager(),
        new InjectionConstructor(
            new Func<string, IWriter>(
                writesTo => container.Resolve<IWriter>(writesTo));
