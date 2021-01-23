    services.Configure<RazorViewEngineOptions>(options =>
    {
        options.FileProvider = new PhysicalFileProvider(HostingEnvironment.WebRootPath + "..\\..\\");
        options.ViewLocationExpanders.Add(new MultiAssemblyViewLocationExpander ());
    });
