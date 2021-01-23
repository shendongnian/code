    public bool OnPreUpdate(PreUpdateEvent @event)
	{
		...
		Set(@event.Persister, @event.State, "UpdatedAt", time);
    ...
    // the way how to assure that even the State is updated
    private void Set(IEntityPersister persister, object[] state
              , string propertyName, object value)
	{
		var index = Array.IndexOf(persister.PropertyNames, propertyName);
		if (index == -1)
			return;
		state[index] = value;
	}
