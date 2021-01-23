    public void RemoveRaiseCustomEventDelegate(Delegate del, string eventName)
    {
        this.GetType()
            .GetEvent(eventName)
            .RemoveEventHandler(this, del);
    }
