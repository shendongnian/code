    ContainerBuilder builder = new ContainerBuilder();
    builder.RegisterGeneric(typeof(XFactory<>))
           .Named("ProjectNamespace.X", typeof(IFooFactory<>));
    builder.RegisterGeneric(typeof(YFactory<>))
           .Named("ProjectNamespace.Y", typeof(IFooFactory<>));
