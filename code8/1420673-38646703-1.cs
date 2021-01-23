    public static void Build(Container container, ApplicationConfig config) {
        // Lot's of registrations
        if (config.AddGlobalExceptionHandler) {
            container.RegisterDecorator(typeof(ICommandHandler<>),
                typeof(GlobalExceptionHandlerCommandHandlerDecorator<>));
        }
    }
