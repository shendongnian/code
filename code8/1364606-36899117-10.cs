	container.RegisterSingleton<ProviderFactory>();
	container.RegisterConditional<IProvider, BingProvider>(
		c => c.Consumer.Target.Name == "bing");
	container.RegisterConditional<IProvider, GoogleProvider>(
		c => c.Consumer.Target.Name == "google");
