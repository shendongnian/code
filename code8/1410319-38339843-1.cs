    public static class EnumExtensions
	{
		public static TAttribute GetAttributeOrDefault<TAttribute>(this Enum enumVal)
			where TAttribute : Attribute
		{
			var type = enumVal.GetType();
			var memInfo = type.GetMember(enumVal.ToString());
			var result = memInfo[0].GetCustomAttributes(typeof(TAttribute), false)
				.FirstOrDefault() as TAttribute;
			return result;
		}
		public static string ToName(this Enum value)
		{
			var result = value.ToString();
			var attribute = value.GetAttributeOrDefault<DisplayAttribute>();
			if (attribute != null)
			{
				result = attribute.Name;
			}
			return result;
		}
		public static string ToShortName(this Enum value)
		{
			var result = value.ToString();
			var attribute = value.GetAttributeOrDefault<DisplayAttribute>();
			if (attribute != null)
			{
				result = attribute.ShortName;
			}
			return result;
		}
	}
