       //builder.RegisterType(typeof(IFoo)).AsImplementedInterfaces();
            ContainerBuilder builder = new ContainerBuilder();
            string[] assemblyScanerPattern = new[] { @"MyModule.*.dll"};
            // Make sure process paths are sane...
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            //  begin setup of autofac >>
            
            // 1. Scan for assemblies containing autofac modules in the bin folder
            List<Assembly> assemblies = new List<Assembly>();
            assemblies.AddRange(
                Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.dll", SearchOption.AllDirectories)
                         .Where(filename => assemblyScanerPattern.Any(pattern => Regex.IsMatch(filename, pattern)))
                         .Select(Assembly.LoadFrom)
                );
        
            foreach (var assembly in assemblies)
            {
                builder.RegisterAssemblyTypes(assembly )
                    .AsImplementedInterfaces();
            }
            var container = builder.Build();
