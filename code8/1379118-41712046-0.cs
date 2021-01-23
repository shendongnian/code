    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Hospital, MongoHospital>().ReverseMap();
        }
        
    }
