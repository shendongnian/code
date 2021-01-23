    public class AutoMapperConfigSet1
    {
        public static void RegisterTypes(MapperConfigurationExpression configuration)
        {
             configuration.CreateMap<Foo, Bar>();
        }
    }
