    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
          Mapper.CreateMap<SoldierDTO, Officer>()
          .ForMember(dest => dest.BaseGroup, opt => opt.MapFrom(src => src.Category))
          .ForMember(dest => dest.ActiveFrom, opt => opt.UseValue(DateTime.Now));
          .ForMember(dest => dest.Type, opt => opt.Ignore());
        }
    }
