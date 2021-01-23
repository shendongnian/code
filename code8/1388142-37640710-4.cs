    Type handlerType = typeof(IMessageHandler<>).MakeGenericType(message.GetType());
    // Resolves the composite handler, wrapping all handlers for T.
    dynamic handler = _container.GetInstance(handlerType);
    // Set the context to allow filtering on namespace
    ContextHelper.ContextNamespace.Value = "Context1Namespace";
    // handle the message
    handler.Handle((dynamic)message);
