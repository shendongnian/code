    public static EnumDescription ConvertEnumWithDescription<T>() where T : struct, IConvertible
	{
		if (!typeof(T).IsEnum)
		{
			throw new ArgumentException("Type given T must be an Enum");
		}
		
		var enumType = typeof(T).Name;
		var valueDescriptions = Enum.GetValues(typeof (T))
			.Cast<Enum>()
			.ToDictionary(Convert.ToInt32, GetEnumDescription);
		
		return new EnumDescription
		{
			Type = enumType,
			ValueDescriptions = valueDescriptions
		};
		
	}
	
	public static string GetEnumDescription(Enum value)
	{
		FieldInfo fi = value.GetType().GetField(value.ToString());
		
		DescriptionAttribute[] attributes =
			(DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
		
		if (attributes.Length > 0)
			return attributes[0].Description;
		return value.ToString();
	}
	
	public class EnumDescription
	{
		public string Type { get; set; }
		public IDictionary<int, string> ValueDescriptions { get; set; }
	}
