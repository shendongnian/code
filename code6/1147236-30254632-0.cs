	public void CreateInstance(Type type)
	{
		var instance = Activator.CreateInstance(type);
		type.GetMethod("method").Invoke(instance, null);
	}
