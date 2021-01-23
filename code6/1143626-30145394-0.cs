    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(map =>
            {
                map.AddProfile<MappingProfile>();
            });
        }
    }
    public class MappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "MappingProfile"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.About, opt => opt.MapFrom(src => src.About))
                .ForMember(dest => dest.IsPublished, opt => opt.MapFrom(src => src.IsPublished))
                .ForMember(dest => dest.IsFinished, opt => opt.MapFrom(src => src.IsFinished))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.Sources, opt => opt.MapFrom(src => src.Sources))
                .ReverseMap();
            // The other models like above...
        }
    }
