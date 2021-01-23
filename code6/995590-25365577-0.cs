    // double
    private static double Parse(string s, NumberStyles style, NumberFormatInfo info)
    {
    	double result;
    	try
    	{
    		result = Number.ParseDouble(s, style, info);
    	}
    	catch (FormatException)
    	{
    		string text = s.Trim();
    		if (text.Equals(info.PositiveInfinitySymbol)) // case-sensitive comparison
    		{
    			result = double.PositiveInfinity;
    		}
    		else
    		{
    			if (text.Equals(info.NegativeInfinitySymbol)) // case-sensitive comparison
    			{
    				result = double.NegativeInfinity;
    			}
    			else
    			{
    				if (!text.Equals(info.NaNSymbol)) // case-sensitive comparison
    				{
    					throw;
    				}
    				result = double.NaN;
    			}
    		}
    	}
    	return result;
    }
