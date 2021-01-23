    protected void Application_Start()
    {
        List<DelegatingHandler> messageHandlers = GlobalConfiguration.Configuration.DependencyResolver.GetMessageHandlers();
        messageHandlers.ForEach(GlobalConfiguration.Configuration.MessageHandlers.Add);
    }
