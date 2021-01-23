    public static string ToStringExt(this DateTime p_Date, String format)
    {
    	foreach (string dateFormatPart in getFormatStrings(format))
    	{
    		if (p_Date.ToString(dateFormatPart) == dateFormatPart)
    		{
    			throw new FormatException("Format Error");
    		}
    	}
    	return p_Date.ToString(format);
    }
    
    private static IEnumerable<string> getFormatStrings(String format)
    {
    	char[] separators = { ' ', '/', '-' };
    	StringBuilder builder = new StringBuilder();
    
    	char previous = format[0];
    	foreach (char c in format)
    	{
    		if (separators.Contains(c) || c != previous)
    		{
    			string formatPart = builder.ToString();
    			if (!String.IsNullOrEmpty(formatPart))
    			{
    				yield return formatPart;
    				builder.Clear();
    			}
    		}
    		if(!separators.Contains(c))
    		{
    			builder.Append(c);
    		}
    		previous = c;
    	}
    	if (builder.Length > 0)
    		yield return builder.ToString();
    }
