    public T InitializeProperties<T, TProperty>(T instance = null) 
		where T : class, new()
		where TProperty : new()
	{
		if (instance == null)
			instance = new T();
		
		var propertyType = typeof(TProperty);
		var propertyInfos = typeof(T).GetProperties().Where(p => p.PropertyType == propertyType);
		
		foreach(var propInfo in propertyInfos)
			propInfo.SetValue(instance, new TProperty());
			
		return instance;
	}
