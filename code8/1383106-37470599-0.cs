    public class BaseClassConstructor {
        public static T Construct<T>(ResolutionContext context) where T : BaseClass, new() {
            if (context == null || context.IsSourceValueNull)
                return null;
            var src = (SourceClass) context.SourceValue;
            return new T() {
                CommonAttr = src.SourceAttr
            };
        }
    }
    /* AutoMapperConfig.cs */
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(config => {
                config
                    .CreateMap<SourceClass, BaseClass>();
                config
                    .CreateMap<SourceClass, DerivedClass1>()
                    .ForMember(dest => dest.Dummy, o => o.MapFrom(src => src.SourceAttr2))
                    .IncludeBase<SourceClass, BaseClass>()
                    .ConstructUsing((s, ctx) => BaseClassConstructor.Construct<DerivedClass1>(ctx));
                config
                    .CreateMap<SourceClass, DerivedClass2>()
                    .ForMember(dest => dest.Dummy, o => o.MapFrom(src => src.SourceAttr2))
                    .IncludeBase<SourceClass, BaseClass>()
                    .ConstructUsing((s, ctx) => BaseClassConstructor.Construct<DerivedClass2>(ctx));
            });
        }
    }
