    // During registration
    var handlerProducerInfos = (
        from type in container.GetTypesToRegister(typeof(IMessageHandler<>), assemblies)
        let registration = Lifestyle.Transient.CreateRegistration(type, container)
        from service in type.GetClosedInterfacesFor(typeof(IMessageHandler<>))
        let producer = new InstanceProducer(service, registration)
        select new
        {
            Producer = new InstanceProducer(service, registration),
            Namespace = type.Namespace
        })
        .ToArray();
    // During execution
    Type handlerType = typeof(IMessageHandler<>).MakeGenericType(message.GetType());
    var handlers =
        from info in handlerProducerInfos
        where handlerType == info.Producer.ServiceType
        where info.Namespace == "Context1Namespace"
        select info.Producer.GetInstance();
    foreach (dynamic handler in handlers) {
    }
