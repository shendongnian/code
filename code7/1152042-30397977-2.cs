    public class MapperConfig
    {
      public static void CreateMappings()
      {
            Mapper.CreateMap<UserDTO, Entities.User>().ReverseMap();
            Mapper.CreateMap<PersonDTO, Entities.Person>().ReverseMap();
    
            Mapper.CreateMap<AddressDTO, Entities.Address>().ReverseMap();
            Mapper.CreateMap<CarDTO, Entities.Car>().ReverseMap();
      }
    }
