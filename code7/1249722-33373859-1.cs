    var assemblies = ScanForTheAssemblies();
    var builder = new ContainerBuilder();
    builder.RegisterModule(new ScanningModule(assemblies));
    ...
    var container = builder.Build();
