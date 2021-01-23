    public static T GetValue<T>(object value)
	{
		if (value == null || value == DBNull.Value)
		{
			return default(T);
		}
		else
		{
			var type = typeof(T);
			
			if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>))) 
			{
				if (value == null) 
				{ 
					return default(T); 
				}
				
				type = Nullable.GetUnderlyingType(type);
			}			
			
			return (T)Convert.ChangeType(value, type);
		}
	}
