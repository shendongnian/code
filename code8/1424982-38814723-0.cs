	_logger.Debug($"Line 1 Context={context.GetHashCode}, Container={Container.GetHashCode()}");
	var db = MyDbContext.ForShard(shardKey.Value);	// no need for "using", since DI will automatically dispose
	_logger.Debug($"Line 2 Context={context.GetHashCode}, Container={Container.GetHashCode()}");
	Container.Configure(cfg => cfg.For<MyDbContext>().Use(db));
	await Next.Invoke(context);
