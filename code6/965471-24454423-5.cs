    container.RegisterSingleOpenGeneric(typeof(EventMediator<>), typeof(EventMediator<>));
    container.ResolveUnregisteredType += (s, e) =>
    {
        if (e.UnregisteredServiceType.IsGenericType)
        {
            var def = e.UnregisteredServiceType.GetGenericTypeDefinition();
            if (def == typeof(IEventPublisher<>) || def == typeof(IEventSubscriber<>))
            {
                var mediatorType = typeof(EventMediator<>)
                    .MakeGenericType(e.UnregisteredServiceType.GetGenericArguments()[0]);
                var producer = container.GetRegistration(mediatorType, true);
                e.Register(producer.Registration);
            }
        }
    };
