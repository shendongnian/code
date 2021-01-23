    public void PublishQueue(IEnumerable<IDomainEvent> domainEvents)
    {
    	foreach (var domainEvent in domainEvents)
    	{
    		var eventType = typeof(Action<>).MakeGenericType(domainEvent.GetType());
    		foreach (var subscriber in subscribers)
    		{
    			if (eventType.IsAssignableFrom(subscriber.GetType()))
    				subscriber.DynamicInvoke(domainEvent);
    		}
    	}
    }
