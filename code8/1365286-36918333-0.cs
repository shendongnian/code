    public enum Status
    {
        [Description("no clue")]
        Unknown,
        [Description("Good!")]
        Good,
        [Description("Bad<angryface>")]
        Bad
    }
    public static class EnumExt
    {
    	public static string Description<T>(this T source)where T : struct, IConvertible
    	{
    		if (!typeof (T).IsEnum)
    		{
    			throw new ArgumentException("T must be an enumerated type");
    		}
    
    		var fi = source.GetType().GetField(source.ToString());
    		var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof (DescriptionAttribute), false);
    		return attributes.Length > 0 ? attributes[0].Description : source.ToString();
    	}
    }
