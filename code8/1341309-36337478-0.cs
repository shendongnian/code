    public static class EnumInfo
    {
    	public static List<KeyValuePair<TEnum, string>> GetList<TEnum>()
    		where TEnum : struct
    	{
    		if (!typeof(TEnum).IsEnum) throw new InvalidOperationException();
    		return ((TEnum[])Enum.GetValues(typeof(TEnum)))
    		   .ToDictionary(k => k, v => ((Enum)(object)v).GetAttributeOfType<DescriptionAttribute>().Description)
    		   .ToList();
    	}
    }
