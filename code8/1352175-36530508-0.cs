    private EventHandler _EventName;
    public event EventHandler EventName
    {
        add
        {
            _EventName = (EventHandler)Delegate.Combine(_EventName, value);
        }
        remove
        {
            _EventName = (EventHandler)Delegate.Remove(_EventName, value);
        }
    }
