    var assemblies = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
       .Where(filePath => Path.GetFileName(filePath).StartsWith("your name space"))
       .Select(Assembly.LoadFrom);
    
    var builder = new ContainerBuilder();
    
    builder.RegisterAssemblyTypes(assemblies.ToArray())
       .Where(t => typeof(ITransientDependency).IsAssignableFrom(t))
       .AsImplementedInterfaces();
