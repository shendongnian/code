    ...
    public class FooMapperProfile:Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<OtherFoo, Foo>();
        }
    }
    
    public class AnotherFooMapperProfile:Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<OtherFoo, AnotherFoo>();
        }
    }
    ... 
    // and so on
