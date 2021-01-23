    var config = new ApplicationConfig();
    // Remove decorator
    config.CommandHandlerDecorators.Remove(
        typeof(AuthorizationCommandHandlerDecorator<>));
    // Add decorator after another decorator
    config.CommandHandlerDecorators.Insert(
        index: 1 + config.CommandHandlerDecorators.IndexOf(
            typeof(TransactionCommandHandlerDecorator<>)),
        item: typeof(DeadlockRetryCommandHandlerDecorator<>));
    // Add an outer most decorator
    config.CommandHandlerDecorators.Add(
        typeof(TestPerformanceProfilingCommandHandlerDecorator<>));
    CompositionRoot.BuildUp(container, config);
    public static void BuildUp(Container container, ApplicationConfig config) {
        // Lot's of registrations here.
        config.CommandHandlerDecorators.ForEach(type =>
            container.RegisterDecorator(typeof(ICommandHandler<>), type));
    }
