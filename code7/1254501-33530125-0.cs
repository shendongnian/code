    public class MyProfile : Profile 
    {
        protected override void Configure()
		{
            // Note, don't use Mapper.CreateType here!
            CreateMap<SomeType1, SomeOtherType1>();
        }
    }
