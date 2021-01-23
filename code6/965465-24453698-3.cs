    var container = new Container();
    container.RegisterOpenGeneric(typeof(IEventSubscriber<>), typeof(EventSubscriber<>));
    container.RegisterOpenGeneric(typeof(IEventPublisher<>), typeof(EventPublisher<>));
    container.RegisterSingleOpenGeneric(typeof(ISubscriptions<>), typeof(Subscriptions<>));
    container.Verify();
    var p = container.GetInstance<IEventPublisher<DummyEvent>>();
    var s = container.GetInstance<IEventSubscriber<DummyEvent>>();
    Assert.That(
        (p as EventPublisher<DummyEvent>).subscriptions  == 
        (s as EventSubscriber<DummyEvent>).subscriptions);
