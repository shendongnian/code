    // container
    var container = new Castle.Windsor.WindsorContainer(); 
    // factory facility, needed to add behavior
    container.AddFacility<TypedFactoryFacility>(); 
    // let's register what we need
    container.Register(
            // your factory interface
            Component.For<IFactory>().AsFactory(),
            // your IBlabla
            Component.For<IBlabla>().ImplementedBy<Blabla>(),
            // component, you could register against an interface
            Component.For<SomeClass>().ImplementedBy<SomeClass>()
        );
    // shazam, let's build our SomeClass
    var result = container.Resolve<IFactory>().Build<SomeClass>("bla?");
