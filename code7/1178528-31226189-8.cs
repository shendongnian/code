    var builder = new ContainerBuilder();
    // Register all of the available transformers.
    builder
        .RegisterTypes(MessageTransformFactory.GetAvailableTransformerTypes())
        .AsImplementedInterfaces()
        .AsSelf();
    // Build the IoC container
    this.container = builder.Build();
    // Define our factory method for resolving the transformer based on device type.
    MessageTransformFactory.SetTransformerFactory((type) =>
    {
        if (!type.IsAssignableTo<IMessageTransformer>())
        {
            throw new InvalidOperationException("The type provided to the message transform factory resolver can not be cast to IMessageTransformer");
        }
        return container.Resolve(type) as IMessageTransformer;
    });
