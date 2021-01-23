    services.ForInterfacesMatching("^I[a-zA-z]+Repository$")
            .OfAssemblies(Assembly.GetExecutingAssembly())
            .AddSingletons();
    
    services.ForInterfacesMatching("^IRepository")
            .OfAssemblies(Assembly.GetExecutingAssembly())
            .AddTransients();
    
    //and so on...
