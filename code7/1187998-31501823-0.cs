	public T PerformQuery<T>(string response)
	{
		if (typeof(T) == typeof(object))
			return new DynamicJsonDeserializer().Deserialize<T>(response);
		
		return new JsonDeserializer().Deserialize<T>(response);
	}
	
