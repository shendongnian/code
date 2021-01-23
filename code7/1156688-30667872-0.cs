    public IBus CreateBus(string connectionString, string consumerName) 
    {
        var bus = RabbitHutch.CreateBus(connectionString);
        // Modify the following to create your error exchange name appropriately
        bus.Advanced.Container.Resolve<IConventions>().ErrorExchangeNamingConvention = 
            info => consumerName + "_ErrorExchange";
        // Modify the following to create your error queue name appropriately
        bus.Advanced.Container.Resolve<IConventions>().ErrorQueueNamingConvention = 
            () => consumerName + "_ErrorQueue";
        return bus;
    }
