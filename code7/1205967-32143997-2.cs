	var builder = new ContainerBuilder();
	builder.RegisterInstance(Console.Out).As<TextWriter>();
	builder.RegisterType<ExceptionLogger>();
	builder.RegisterType<StringWorker>()
           .As<IWorker<string>>()
           .EnableInterfaceInterceptors()
           .InterceptedBy(typeof(ExceptionLogger));
	var container = builder.Build();
	var worker = container.Resolve<IWorker<string>>();
	worker.DoWork("Test!");
