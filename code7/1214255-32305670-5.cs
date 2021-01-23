    var container = new Container(_ =>
    {
        _.For<CommandFactory>().Use(context=>new CommandFactory(context));
    });
    var factory = container.GetInstance<CommandFactory>();
    var command = factory.CreateCommand(Services.Service_One);
    command.Handle();
