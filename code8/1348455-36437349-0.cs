	public static T CleanNullishStrings<T>(this T obj) where T : class
	{
		foreach (System.Reflection.PropertyInfo property in obj.GetType().GetProperties())
		{
			if (property.PropertyType == typeof(string) && property.CanRead && property.CanWrite)
			{
				string value = (string)property.GetMethod.Invoke(obj, null);
				value = string.IsNullOrEmpty(value) || value.ToUpper() == "NULL" ? null : value;
				property.SetMethod.Invoke(obj, new object[] { value });
			}
		}
		return obj;
	}
