    // Useful helper method
	static bool InjectedInto<TConsumer>(PredicateContext c) =>
        c.Consumer.ImplementationType == typeof(TConsumer);
	container.Register<ScopedWorker>(Lifestyle.Scoped);
	container.Register<SingletonWorker>(Lifestyle.Singleton);
	container.RegisterConditional<IMetricSubmitter, DefaultMetricSubmitter>(
        Lifestyle.Singleton,
		InjectedInto<CachingMetricSubmitterDecorator>);
	container.RegisterConditional<IMetricSubmitter, CachingMetricSubmitterDecorator>(
        Lifestyle.Singleton,
		c=> !InjectedInto<ScopedWorker>(c)&&!InjectedInto<CachingMetricSubmitterDecorator>(c));
	container.RegisterConditional<IMetricSubmitter, EnrichMetricsDecorator>(
        Lifestyle.Scoped, 
        InjectedInto<ScopedWorker>);
