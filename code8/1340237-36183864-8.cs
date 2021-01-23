    public CommunicationService (StandardKernel kernel) 
    {
        context = kernel.Get<IContext>();
    }
    
    public CommunicationService(NinjectModule injectModule):this (new StandardKernel(injectModule))
    {
        context = kernel.Get<IContext>();
    }
    
    public CommunicationService():this (new NinjectConfig())
    {}
