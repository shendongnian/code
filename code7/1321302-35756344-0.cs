    private static readonly MethodInfo PublishMethod = typeof(DomainEventDispatcher).GetMethod("Publish"); // .GetMethods().Single(m => m.Name == "Publish" && m.IsGenericMethodDefinition);
    
    public void PublishQueue(IEnumerable<IDomainEvent> domainEvents)
    {
    	foreach (var domainEvent in domainEvents)
    	{
    		var publish = PublishMethod.MakeGenericMethod(domainEvent.GetType());
    		publish.Invoke(this, new[] { domainEvent });
    	}
    }
