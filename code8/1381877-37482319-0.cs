    // find actual type and unproxy the entity
    object unproxiedEntity = mayBeProxy;
	INHibernateProxy proxy = mayBeProxy as INHibernateProxy;
	if (proxy != null)
	{
		unproxiedEntity = proxy.HibernateLazyInitializer.GetImplementation();
	}
	var type = unproxiedEntity.GetType()
