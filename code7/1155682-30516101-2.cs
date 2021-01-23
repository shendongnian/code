    public static class MappingConfig
    {
        public static void InitializeMappings()
        {
            Mapper.Initialize(configuration => Configure(configuration));
        }
        public static void Configure(IConfiguration configuration)
        {
            
            configuration.CreateMap<Model, ViewModel>()
            configuration.Seal();
        }
    }
