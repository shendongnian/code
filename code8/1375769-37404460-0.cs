    _test = TestFactory.ForConsumer<AnimalSubscriber>()
        .InSingleBusScenario()
        .New(x =>
            {
                x.ConstructUsing(() => new AnimalSubscriber());
                x.Send(new Animal(), (scenario, context) => context.SendResponseTo(scenario.Bus));
            });
    _test.Execute();
