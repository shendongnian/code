    if(!container.ComponentRegistry.IsRegistered(new TypedService(handlerType)))
    {
        continue;
    }
    Type handlerFactoryType = typeof(Func<>).MakeGenericType(
                                typeof(Owned<>).MakeGenericType(handlerType)); 
    var handlerFactory = (Func<Owned<INotificationCustomHandler>>)container
                               .Resolve(handlerFactoryType);
    
    using(Owned<INotificationCustomHandler> ownedHandler = handlerFactory())
    {
        INotificationCustomHandler handler = ownedHandler.Value; 
        Retry.Execute(() => handler.Send(entity, destination), 3, 500);
    } // handler will be disposed here 
