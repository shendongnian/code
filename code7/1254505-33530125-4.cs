    public class MyProfile : Profile 
    {
        protected override void Configure()
		{
            // Note, don't use Mapper.CreateMap here!
            CreateMap<SomeType1, SomeOtherType1>();
        }
    }
