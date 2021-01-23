   public class MyProjectAutoMapperProfile : AutoMapper.Profile {
        protected override void Configure() {
            CreateMap&lt;SourceClass, DestClass>()
                .ForMember(dest => dest.AB,
                           opts => opts.MapFrom(src => (src.A + ", " + src.B)));
            // other customs here...
        }
