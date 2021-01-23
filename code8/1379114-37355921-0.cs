    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(
                config =>
                {
                    config.CreateMap<Hospital, MongoHospital>()
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
                });
        }
    }
