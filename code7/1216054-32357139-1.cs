	public static string GetEnumDescription<T>(Enum value)
        where T : DescriptionAttribute
	{
		var fi = value.GetType().GetField(value.ToString());
		var attributes = fi.GetCustomAttributes(typeof (T), false);
		var theDescriptionAttribute = attributes.FirstOrDefault(x => x.GetType() == typeof (T)) as T;
		if (theDescriptionAttribute == null)
		{
			return string.Empty;
		}
		return theDescriptionAttribute.Description;
	}
