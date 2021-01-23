    public class ComplexTypeConverter : ITypeConverter<ComplexSourceType, ComplexDestinationType>
    {
        public ComplexDestinationType Convert(ResolutionContext context)
        {
            var source = (ComplexSourceType)context.SourceValue;
            return new ComplexDestinationType
            {
                MyProperty = Mapper.Map<SourceType, DestinationType>(source.MyProperty),
                ValueComputed = source.ValueToBeComputed + 10
            };
        }
    }
    public class TypeConverter : ITypeConverter<SourceType, DestinationType>
    {
        public DestinationType Convert(ResolutionContext context)
        {
            var source= (SourceType)context.SourceValue;
            return new DestinationType
            {
                ValueComputed1 = source.ValueToBeComputed1 + 10,
                ValueComputed2 = source.ValueToBeComputed2 + 10
            };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ComplexSourceType, ComplexDestinationType>().ConvertUsing(new ComplexTypeConverter());
                cfg.CreateMap<SourceType, DestinationType>().ConvertUsing(new TypeConverter());
            });
            Mapper.AssertConfigurationIsValid();
            ComplexSourceType source = new ComplexSourceType
            {
                MyProperty = new SourceType
                {
                    ValueToBeComputed1 = 1,
                    ValueToBeComputed2 = 1
                },
                ValueToBeComputed = 1
            };
            var dest = Mapper.Map<ComplexSourceType, ComplexDestinationType>(source);
        }
    }
