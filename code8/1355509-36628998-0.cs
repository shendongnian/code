	public override void Load()
	{
		var setting = ConfigurationManager.AppSettings["Server"].ToUpper();
		var type = (setting == "LIVE")
            ? ServiceInterface.ServerType.Azurerelay_live
            : ServiceInterface.ServerType.Azurerelay_test;
		Kernel.Bind<IServiceInterface>().ToMethod(c => new ServiceInterface(type));
        Kernel.Bind<IModelFactory>().ToMethod(c => new ModelFactory());
    }
