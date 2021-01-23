    var container = new LightInject.ServiceContainer();
    //register your command passing a user instance
    container.Register<ICommand>(factory => new Welcome(factory.GetUser<IUser>(request)));
    
    using (var scope = container.BeginScope())
    {        
        var command = (ICommand)container.GetInstance<ICommand>();
        return command.Do();
    }
