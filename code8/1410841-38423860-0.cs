    internal class Program
	{
		public static void Main()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<SourceAddress, DestinationAddress>();
				cfg.CreateMap<SourceContact, DestinationContact>();
				cfg.CreateWrapMap(
                    //func selecting types to wrap
					type => typeof(DestinationModelBase).IsAssignableFrom(type)
							&& !type.IsAbstract,
					typeof(Wrap<>),
					typeof(MapAndWrapConverter<,>));
			});
			var mapper = config.CreateMapper();
            //Using AutoFixture to create complex object
			var fixture = new Fixture();
			var srcObj = fixture.Create<SourceContact>();
			var dstObj = mapper.Map<Wrap<DestinationContact>>(srcObj);
		}
	}
	public static class AutoMapperEx
	{
		public static IMapperConfigurationExpression CreateWrapMap(
			this IMapperConfigurationExpression cfg,
			Func<Type, bool> needWrap, Type wrapperGenericType,
			Type converterGenericType)
		{
			var mapperConfiguration = 
                new MapperConfiguration((MapperConfigurationExpression)cfg);
			var types = Assembly.GetExecutingAssembly().GetTypes();
			foreach (var dstType in types.Where(needWrap))
			{
				var srcType = mapperConfiguration.GetAllTypeMaps()
					.Single(map => map.DestinationType == dstType).SourceType;
				var wrapperDstType = wrapperGenericType.MakeGenericType(dstType);
				var converterType = converterGenericType.MakeGenericType(srcType, dstType);
				cfg.CreateMap(srcType, wrapperDstType)
					.ConvertUsing(converterType);
			}
			return cfg;
		}
	}
	public class MapAndWrapConverter<TSource, TDestination> 
		: ITypeConverter<TSource, Wrap<TDestination>>
	{
		public Wrap<TDestination> Convert(
			TSource source, Wrap<TDestination> destination, ResolutionContext context)
		{
			return new Wrap<TDestination>
			{
				Payload = context.Mapper.Map<TDestination>(source)
			};
		}
	}
