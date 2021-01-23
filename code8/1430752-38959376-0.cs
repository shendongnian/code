    protected override void RegisterTypes()
    		{
    			DependencyService ds = new DependencyService();
    			Container.RegisterType<IUnitOfWork, UnitOfWork>(new InjectionConstructor(ds.Get<ISQLite>()));
    ....
    }
		
			
