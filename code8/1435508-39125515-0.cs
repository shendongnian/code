    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                //The map for the outer types
                cfg.CreateMap<SourceType, DestinationType>()
                    .ForMember(dest => dest.Type3Property, opt => opt.MapFrom(src => src.Inner));
                //The map for the inner types
                cfg.CreateMap<InnerSourceType, Type3>();
                //The map for the nested properties in the inner types
                cfg.CreateMap<Type6, Type5>()
                    //You only need to do this if your property names are different
                    .ForMember(dest => dest.MyType5Value, opt => opt.MapFrom(src => src.MyType6Value));
    
            });
    
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
    
            var source = new SourceType
            {
                Inner = new InnerSourceType {
                    OldValue = new Type6 { MyType6Value = 15 },
                    NewValue = new Type6 { MyType6Value = 20 }
                }
            };
    
            var result = mapper.Map<SourceType, DestinationType>(source);
        }
    }
    
    public class SourceType
    {
        public InnerSourceType Inner { get; set; }
    }
    
    public class InnerSourceType
    {
        public Type6 OldValue { get; set; }
        public Type6 NewValue { get; set; }
    }
    
    public class DestinationType
    {
        public Type3 Type3Property { get; set; }
    }
    
    //Inner destination
    public class Type3
    {
        public Type5 OldValue { get; set; }
        public Type5 NewValue { get; set; }
    }
    
    public class Type5
    {
        public int MyType5Value { get; set; }
    }
    
    public class Type6
    {
        public int MyType6Value { get; set; }
    }
