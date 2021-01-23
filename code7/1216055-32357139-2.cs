	public static string GetEnumDescription(Enum value)
	{
		var fi = value.GetType().GetField(value.ToString());
		var attributes = fi.GetCustomAttributes(typeof (DescriptionAttribute), false);
		var theDescriptionAttribute = attributes.FirstOrDefault(x => x.GetType() == typeof (DescriptionAttribute)) as DescriptionAttribute;
		if (theDescriptionAttribute == null)
		{
			return string.Empty;
		}
		return theDescriptionAttribute.Description;
	}
