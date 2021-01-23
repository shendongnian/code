    private void AddBindings(IKernel container)
    {
    	container.Bind<IUnitOfWork>().To<TRZICDbContext>().InRequestScope();
    
    	container.Bind<IGenericRepository<CONFIGURATIONS>>().
    		To<GenericRepository<CONFIGURATIONS>>();
    	container.Bind<IGenericRepository<INCREMENTAL_TABLE>>().
    		To<GenericRepository<INCREMENTAL_TABLE>>().WithConstructorArgument("unitOfWork", new INICDbContext());
    
    	// More code..
    }
