	kernel.Bind(typeof(ICacheManager<>)).ToMethod((context) =>
	{
		// GenericArguments holds the actual type for ICacheValue used in the ICachManager property or argument
		return CacheFactory.FromConfiguration(context.GenericArguments[0], "defaultCache");
	});
