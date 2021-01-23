    container
        .RegisterType<IProcessingService, ProcessingService>(new InjectionFactory((c, type, name) =>
        {
            return new ProcessingService(c.Resolve<ISomeClass1>(), new SomeClass2(type));
        }));
