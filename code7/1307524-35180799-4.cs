    public async Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
    {
        if (@event == null)
        {
            throw new ArgumentNullException(nameof(@event));
        }
        var handlerType = typeof (IEventHandler<>).MakeGenericType(@event.GetType());
        var handlerCollectionType = typeof (IEnumerable<>).MakeGenericType(handlerType);
        var eventHandlers = _context.Resolve(handlerCollectionType);
        foreach (IEventHandler<TEvent> handler in eventHandlers)
        {
            await handler.Handle(@event);
        }
    }
