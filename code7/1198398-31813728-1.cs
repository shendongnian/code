    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
             Mapper.CreateMap<EstateViewModel, Estate>();          
        }
    }
