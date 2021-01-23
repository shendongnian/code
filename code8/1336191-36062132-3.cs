	public NinjectControllerFactory()
	{
		_ninjectKernal = new StandardKernel();
		_ninjectKernal.Bind<IPSCCheckContext>().To<PSCCheckContext>()
			.WithConstructorArgument("appNamekey", "Name of Staff Application")
			.WithConstructorArgument("serverLocationNameKey", "Location of Application Server");
		AddBindings();
	}
