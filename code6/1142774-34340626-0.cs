    public static class EnumExtensions
    {
    	public static string ToDisplayString(this Enum value)
    	{
    		var converter = TypeDescriptor.GetConverter(value);
    		return converter.ConvertToString(value);
    	}
    }
