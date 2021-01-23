    var bus = new EventBus();
    var disposable = bus.GetEventStream<SomeEvent>.Subscribe(ev => Console.WriteLine("It happened!"));
    // some time later
    bus.Publish(new SomeEvent());
    // you can also unsubscribe from the stream
    disposable.Dispose();
