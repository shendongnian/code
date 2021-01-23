    public class CustomResolver : ValueResolver<Source, string>
    {
        protected override string ResolveCore(Source source)
        {
            return source.CountryOfRisk ?? source.Issuer.CountryOfRisk;
        }
    }
    
    Mapper.Initialize(cfg => 
       cfg.CreateMap<Source, Destination>()
           .ForMember(dest => dest.CountryOfRisk, opt => opt.ResolveUsing<CustomResolver>());
