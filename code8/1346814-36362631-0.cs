    public class AutoMapperConfig
    {
      public static void RegisterMappings()
      {
        Mapper.Initialize(cfg =>
        {
          cfg.CreateMap<Class1, Class2>();
          cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
          cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        });
      }
    }
