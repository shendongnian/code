    public static class AutoMapping
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.CreateMap<MyModel, MyDto>().ReverseMap();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
