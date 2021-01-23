	public static Dictionary<TEnum, string> ToDictionary<TEnum>(this Type type)
        where TEnum : struct, IComparable, IFormattable, IConvertible
	{
		return Enum.GetValues(type)
                   .OfType<TEnum>()
                   .ToDictionary(value => value, value => value.Description());
	}
