    public virtual Type GetTypeForRecord<T>(T record)
	{
		var type = typeof(T);
		if (type == typeof(object))
		{
			type = record.GetType();
		}
		return type;
	}
