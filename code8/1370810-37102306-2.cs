    public void RouteToEventHandler(object userEvent)
    {
        if (userEvent == null)
        {
            return;
        }
        var handler = handlers[userEvent.GetType()];
        handler.HandleEvent(userEvent);
    }
