    private readonly List<ISubscriber> _subscribers = new List<ISubscriber>();
    
    public void CreateConnection(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }
    private void OnConnectedNotifySubscribers()
    {
        foreach (ISubscriber subscriber in _subscribers)
        {
            subscriber.OnConnected();
        }
    }
