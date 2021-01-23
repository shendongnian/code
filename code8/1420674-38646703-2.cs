    var config = new ApplicationConfig();
    config.CommandHandlerDecorators
        .Remove(typeof(GlobalExceptionHandlerCommandHandlerDecorator<>));
    config.CommandHandlerDecorators
        .Add(typeof(TestProfilingCommandHandlerDecorator<>));
    CompositionRoot.BuildUp(container, config);
    public static void BuildUp(Container container, ApplicationConfig config) {
        // Lot's of registrations here.
        config.CommandHandlerDecorators.ForEach(type =>
            container.RegisterDecorator(typeof(ICommandHandler<>), type));
    }
