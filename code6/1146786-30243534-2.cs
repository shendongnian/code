    ContainerBuilder builder = new ContainerBuilder();
    String path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    IEnumerable<Assembly> assemblies = Directory.GetFiles(path, "*.dll")
                                                .Select(Assembly.LoadFrom);
    builder.RegisterAssemblyModules(assemblies);
