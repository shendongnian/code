    public void Read<T>() where T : class, new()
	{
		// Create an instance of our generic class
		var model = new T();
		var properties = typeof(T).GetProperties();
		// Loop through the objects properties
		foreach(var property in properties)
		{
			// Set our value
			SetPropertyValue(property, model, "test");
		}
	}
	private void SetPropertyValue(PropertyInfo property, object model, string value)
	{
		if (property.PropertyType == typeof(string))
		{
			// Set our property value
			property.SetValue(model, value, null);
		}
		else
		{
			var submodel = Read(property.PropertyType);
			property.SetValue(model, submodel, null);
		}
	}
	private object Read(Type type)
	{
		if (!IsTypeSupported(type))
		{
			throw new ArgumentException();
		}
		var model = type.GetConstructor(new Type[0]).Invoke(new object[0]);
		var properties = type.GetProperties();
		foreach (var property in properties)
		{
			SetPropertyValue(property, model, "test");
		}
		return model;
	}
	private bool IsTypeSupported(Type type)
	{
		return type.IsClass && type.GetConstructor(new Type[0]) != null;
	}
