public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<Source, Destination>()
                .ForMember(d => d.Bar,
                    opt => opt.MapFrom(
                        (src, dst, _, context) => context.Options.Items["bar"]
                    )
                );    
        }
    }
**Mapping**
var destination = mapper.Map<Destination>(
    source,opt => {
        opt.Items["bar"] = "baz";
    }
);
