    public static class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfiguration;
        public static void RegisterMappings()
        {
            MapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<Source, Dest>().ReverseMap();
            });
        }
    }
