    /// <summary>
    /// Registers the view models in the Simple Injector container
    /// </summary>
    /// <param name="container">The Simple Injector container</param>
    /// <param name="viewModelAssemblies">The assembly location of the view models</param>
    public static void RegisterViewModels(this Container container, Assembly[] viewModelAssemblies)
    {
    	if (container == null)
    		throw new ArgumentNullException("container");
    
    	if (viewModelAssemblies == null) 
    		throw new ArgumentNullException("viewModelAssemblies");
    
    	container.RegisterSingle<IProcessViewModels, ViewModelProcessor>();
    	container.RegisterManyForOpenGeneric(typeof(IHandleViewModel<>), viewModelAssemblies);
    	container.RegisterManyForOpenGeneric(typeof(IHandleViewModel<,>), viewModelAssemblies);
    }
