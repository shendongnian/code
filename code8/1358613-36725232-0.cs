    public static void Configure()
    {
        MapperConfiguration = new MapperConfiguration(cfg => {
            cfg.AddProfile<Out>();
        });
        MapperConfiguration.AssertConfigurationIsValid();
    }
    ...
