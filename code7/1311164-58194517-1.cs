    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            MapperWrapper.Initialize(cfg =>
            {
                cfg.CreateMap<Foo1, Foo2>();              
            });
            MapperWrapper.AssertConfigurationIsValid();
        }
    }
