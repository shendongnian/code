	container.Register<ScopedWorker>(Lifestyle.Scoped);
	container.Register<SingletonWorker>(Lifestyle.Singleton);
	container.RegisterConditional<IMetricSubmitter, EnrichMetricsDecorator>(
		Lifestyle.Scoped,
		c => c.Consumer.ImplementationType == typeof(ScopedWorker));
	container.RegisterConditional<IMetricSubmitter, DefaultMetricSubmitter>(
		Lifestyle.Singleton,
		c => c.Consumer.ImplementationType != typeof(EnrichMetricsDecorator));
