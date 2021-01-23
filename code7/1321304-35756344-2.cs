    private static Action<DomainEventDispatcher, IDomainEvent> CreatePublishFunc(Type eventType)
    {
    	var dispatcher = Expression.Parameter(typeof(DomainEventDispatcher), "dispatcher");
    	var domainEvent = Expression.Parameter(typeof(IDomainEvent), "domainEvent");
    	var call = Expression.Lambda<Action<DomainEventDispatcher, IDomainEvent>>(
    		Expression.Call(dispatcher, "Publish", new [] { eventType },
    			Expression.Convert(domainEvent, eventType)),
    		dispatcher, domainEvent);
    	return call.Compile();
    }
    private static readonly Dictionary<Type, Action<DomainEventDispatcher, IDomainEvent>> publishFuncCache = new Dictionary<Type, Action<DomainEventDispatcher, IDomainEvent>>();
    private static Action<DomainEventDispatcher, IDomainEvent> GetPublishFunc(Type eventType)
    {
    	lock (publishFuncCache)
    	{
    		Action<DomainEventDispatcher, IDomainEvent> func;
    		if (!publishFuncCache.TryGetValue(eventType, out func))
    			publishFuncCache.Add(eventType, func = CreatePublishFunc(eventType));
    		return func;
    	}
    }
    
    public void PublishQueue(IEnumerable<IDomainEvent> domainEvents)
    {
    	foreach (var domainEvent in domainEvents)
    	{
    		var publish = GetPublishFunc(domainEvent.GetType());
    		publish(this, domainEvent);
    	}
    }
