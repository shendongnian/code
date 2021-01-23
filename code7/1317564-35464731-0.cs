    public class MyProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            CreateMap<SourceClass, DestClass>();
        }
    }
