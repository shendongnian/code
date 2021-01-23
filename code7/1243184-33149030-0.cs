    UnityContainer
        .RegisterType<IMessagingService, SessionMessagingService>("SessionMessageService")
    
    UnityContainer
        .RegisterType<IMessagingService, BrowseMessagingService>("BrowseMessagingService")
