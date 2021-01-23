    // Register Components...
    ContainerBuilder builder = new ContainerBuilder();
    builder.RegisterType<MyProfile>().As<Profile>();
    // This could also be done with assembly scanning...
    builder.RegisterAssemblyTypes(typeof<MyProfile>.Assembly).As<Profile>();
    
    // Build container...
    var container = builder.Build();
    // Configure AutoMapper
    var profiles = container.Resolve<IEnumerable<Profile>>();
    Mapper.Initialise(cfg => 
    {
        foreach (var profile in profiles)
        {
            cfg.AddProfile(profile);
        }
    });
