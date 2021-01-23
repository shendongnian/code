    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(
                cfg =>
                {
                    cfg.AddProfile<HospitalProfile>();
                }
            );
        }
    }
    public class HospitalProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Hospital, MongoHospital>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
