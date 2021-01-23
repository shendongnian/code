    var serviceBusConfig = new ServiceBusConfiguration
    { 
        ConnectionString = config.ServiceBusConnectionString
    };
    serviceBusConfig.MessagingProvider = new ScopedMessagingProvider(serviceBusConfig, container);
    jobHostConfig.UseServiceBus(serviceBusConfig);
