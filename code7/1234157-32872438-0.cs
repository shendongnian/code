    foreach(Type interfaceType in listener.GetType().GetInterfaces())
    {
        if(interfaceType.GetInterfaces().Contains(typeof(IEventListener)))
        {
            AddSubscriber(interfaceType.GetGenericArguments()[0], listener);
        }
    }
