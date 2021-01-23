    public static class AutoMapperExtensions
    {
    	public static void NullSubstitute<TSource, TDestination>(this Profile profile, TSource nullSubstitute)
    		where TSource : struct
    	{
    		object value = nullSubstitute;
    		profile.ForAllPropertyMaps(
    			map => map.SourceType == typeof(TSource?) && 
    			       map.DestinationPropertyType == typeof(TDestination),
    			(map, config) => config.NullSubstitute(value)
    		);
    	}
    }
