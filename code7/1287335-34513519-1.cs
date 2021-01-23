    public class XProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<SourceClass, DestinationClass>()
                .ConstructUsing(x => new DestinationClass(x.Strings));
        }
    }
