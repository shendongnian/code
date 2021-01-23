	public NinjectControllerFactory()
	{
		_ninjectKernal = new StandardKernel();
		PSCCheckContext m = _ninjectKernal.Get<PSCCheckContext>(new IParameter[] 
			{ new ConstructorArgument("appNamekey", "Name of Staff Application"), 
				new ConstructorArgument("serverLocationNameKey", "Location of Application Server") });
		AddBindings();
	}
