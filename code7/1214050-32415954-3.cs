    // Note that the strings used here for instance names have nothing 
    // to do with the strings used to select the instance in the strategy pattern
	unityContainer.RegisterType<IAuthenticate, TwitterAuth>("twitterAuth");
	unityContainer.RegisterType<IAuthenticate, FacebookAuth>("facebookAuth");
	unityContainer.RegisterType<IAuthenticateStrategy, AuthenticateStrategy>(
		new InjectionConstructor(
			new ResolvedArrayParameter<IAuthenticate>(
				new ResolvedParameter<IAuthenticate>("twitterAuth")
			),
			new ResolvedArrayParameter<IAuthenticate>(
				new ResolvedParameter<IAuthenticate>("facebookAuth")
			)
		));
