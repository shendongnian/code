    var containerBuilder = new ContainerBuilder();
    containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);
    var libFolder = new DirectoryInfo(HostingEnvironment.MapPath("~/bin"));
    var libFiles = libFolder.GetFiles("*.dll", SearchOption.AllDirectories);
    foreach (var lib in libFiles)
    {
         var asm = Assembly.LoadFrom(lib.FullName);
         containerBuilder.RegisterAssemblyModules(asm);
    }
    var container = containerBuilder.Build();
