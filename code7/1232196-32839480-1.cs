    ContainerBuilder builder = new ContainerBuilder();
    var owners = new ConcurrentDictionary<IService, IOwner>();
    builder.RegisterType<MyService>().As<IService>().OnRelease(o =>
    {
        IOwner owner;
        owners.TryRemove(o, out owner);
    });
    builder.RegisterType<Owner>().Named<IOwner>("newOwner");
    builder.Register(c =>
    {
        IEnumerable<Parameter> parameters = Enumerable.Empty<Parameter>();
        IInstanceLookup instanceLookup = c as IInstanceLookup;
        if (instanceLookup != null)
        {
            parameters = instanceLookup.Parameters;
        }
        IService service = parameters.OfType<TypedParameter>()
                                     .Where(tp => tp.Type == typeof(IService))
                                     .Select(tp => tp.Value)
                                     .OfType<IService>()
                                     .FirstOrDefault();
        if (service == null)
        {
            service = c.Resolve<IService>();
            parameters = parameters.Concat(new Parameter[] {
                TypedParameter.From<IService>(service)
            });
        }
        IOwner owner = owners.GetOrAdd(service, _ =>
            c.ResolveNamed<IOwner>("newOwner", parameters)
        );
        return owner;
    }).As<IOwner>();
    IContainer container = builder.Build();
