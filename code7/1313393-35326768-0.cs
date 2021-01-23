	var hubConfiguration = new HubConfiguration
	{
		Resolver = new AutofacDependencyResolver(resolver)
		//, EnableDetailedErrors = true
	};
	app.UseAutofacMiddleware(resolver);
	app.MapSignalR("/signalr", hubConfiguration);
	hubConfiguration.Resolver.UseRedis(new RedisScaleoutConfiguration(redisConnectionString, signalrRedisKey));
