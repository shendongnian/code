    container.RegisterSingleton<IProviderContext>(new AspNetProviderContext());
    var bing = Lifestyle.Singleton.CreateProducer<IProvider, BingProvider>(container);
    var google = Lifestyle.Singleton.CreateProducer<IProvider, GoogleProvider>(container);
	container.RegisterSingleton<IProvider>(new ProviderDispatcherProxy(
		bingProvider: bing.GetInstance,
		googleProvider: google.GetInstance));
