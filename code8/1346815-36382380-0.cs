    public static void RegisterMappings()
    {
        MapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            cfg.CreateMap<Class1, Class2>();
        });
    }
