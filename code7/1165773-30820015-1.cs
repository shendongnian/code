    public static class AutoMapperConfig
    {
       public static void Configure()
       {    
          Mapper.CreateMap<ErrorsLog, ErrorsLogViewModel>();
       }
    }
