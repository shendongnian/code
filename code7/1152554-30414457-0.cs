    namespace Library.Infrastructure.AutoMapper
    {
       public static class Configuration
       {
          public static void MapTypes()
          {
             Mapper.CreateMap<Type2, Type1>()
                .ConstructUsing(t => new Type1(t.Guid, ...));
             ...
          }
       }
    }
