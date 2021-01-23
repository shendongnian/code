    public CommunicationService(NinjectModule injectModule) 
    {
    	var kernel = new StandardKernel(injectModule);
        context = kernel.Get<IContext>();
    }
    
    public CommunicationService():this (new NinjectConfig())
    {}
