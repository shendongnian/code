    event Action MyEvent;
    bool IsEventHandlerAdded()
    {
        foreach (Delegate existingHandler in this.MyEvent.GetInvocationList())
        {
            return existingHandler == MyEvent;
        }
        return false;
    }
