    public class MapperConfig : Profile
    {
        protected override void Configure()
        {
            CreateMap<Foo, Bar>()
                .ForMember(dest => dest.TestValue,
                    e => e.MapFrom(source =>
                        source.TestValue == null
                            ? MyStrangeEnum.NullValue
                            : source.TestValue.Value ? MyStrangeEnum.True : MyStrangeEnum.False));
        }
    }
    public class Foo
    {
        public Foo()
        {
            TestValue = true;
        }
        public bool? TestValue { get; set; }
    }
    public class Bar
    {
        public MyStrangeEnum TestValue { get; set; }
    }
    public enum MyStrangeEnum
    {
        NullValue = -1,
        False = 0,
        True = 1
    }
