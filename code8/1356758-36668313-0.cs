    var builder = new ContainerBuilder();
    builder.RegisterGeneric(typeof(ContactService<>))
        .As(typeof(IContactService<>));
    builder.RegisterGeneric(typeof(ContactService<>))
        .As(typeof(IFeatureProvider<>));
    var container = builder.Build();
    var service = container.Resolve(typeof(IFeatureProvider<ContactFeature<Household>>));
    var service2 = container.Resolve(typeof(IContactService<Household>));
    Console.WriteLine(service.GetType());
    Console.WriteLine(service2.GetType());
    Console.ReadKey();
