    var builder = new ContainerBuilder();
    // Usually you're only interested in exposing the type
    // via its interface:
    builder
        .RegisterType<GenericIocFactory>()
        .As<IGenericIocFactory>();
    builder
        .RegisterType<CustomAutoFacContainer>()
        .As<ICustomAutoFacContainer>();
    builder
        .RegisterType<Product>()
        .As<IProduct>()
        .PropertiesAutowired();
    var container = builder.Build();
    var factory = container.Resolve<IGenericIocFactory>();
    _product = factory.Get<IProduct>(false) as Product;
    _product = factory.Get<IProduct>("","") as Product;
