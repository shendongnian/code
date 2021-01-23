    var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        var host = cfg.Host(new Uri("rabbitmq://localhost"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.Send<TestMessage>(x => { x.UseRoutingKeyFormatter(context => "routingKey"); });
        cfg.Message<TestMessage>(x => x.SetEntityName("TestMessage"));
        cfg.Publish<TestMessage>(x => { x.ExchangeType = ExchangeType.Direct; });
        cfg.ReceiveEndpoint(host, "TestMessage_Queue", e =>
        {
            e.BindMessageExchanges = false;
            e.Consumer<UpdateCustomerConsumer>();
            e.Bind("TestMessage", x =>
            {
                x.ExchangeType = ExchangeType.Direct;
                x.RoutingKey = "routingKey";
            });
        });
    });
    
    bus.Start();
