    var container = new SimpleInjector.Container();
    container.RegisterOpenGeneric(typeof(EventMediator<>), typeof(EventMediator<>), 
        Lifestyle.Singleton);
    container.RegisterOpenGeneric(typeof(IEventPublisher<>), typeof(EventMediator<>));
    container.RegisterOpenGeneric(typeof(IEventSubscriber<>), typeof(EventMediator<>));
    container.Verify();
    var p = container.GetInstance<IEventPublisher<DummyEvent>>();
    var s = container.GetInstance<IEventSubscriber<DummyEvent>>();
    var areSame = (object.ReferenceEquals(p, s));
