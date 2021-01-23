    private readonly List<Action<object>> subscribers = new List<Action<object>>();
    public void Subscribe<TEvent>(Action<TEvent> subscriber) where TEvent : class
    {
        subscribers.Add((object evnt) =>
        {
            var correctType = evnt as TEvent;
            if (correctType != null)
            {
                subscriber(correctType);
            }
        });
    }
    public void Publish(object evnt)
    {
        foreach (var subscriber in subscribers)
        {
            subscriber(evnt);
        }
    }
