	public static void SetPropertyValue(object obj, string propName, object value)
	{
		obj.GetType().GetProperty(propName).SetValue(obj, value, null);
	}
		
