    var container = new Container(_ =>
    {
        _.For<ICommandFactory>().Use(context=>new CommandFactory(context));
    });
    var factory = container.GetInstance<ICommandFactory>();
    var command = factory.CreateCommand(Services.Service_One);
    command.Handle();
