	public static DateTime ToDate(this string value, string format)
	{
		return DateTime.ParseExact(value, format, CultureInfo.InvariantCulture);
	}
	
