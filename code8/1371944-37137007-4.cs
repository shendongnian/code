	public static T GetValue<T>(object value)
	{
		if (value == null || value == DBNull.Value)
		{
			return default(T);
		}
		else if (value.GetType().IsGenericType
              && value.GetType().GetGenericTypeDefinition().Equals(typeof(List<>)))
		{
			var list = ((System.Collections.IList)value).Cast<object>();
			
			if (!list.Any())
				return default(T);
			
			return GetValue<T>(list.Single());
		}
		else
		{
			var type = typeof(T);
			
			if (type.IsGenericType
             && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
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
