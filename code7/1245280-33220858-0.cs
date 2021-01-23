    public static decimal ConvertAsDecimal(this string input, decimal defaultValue = default(decimal))
    {
    	if (!string.IsNullOrWhiteSpace(input))
    	{
    		decimal result;
    		if (decimal.TryParse(input, out result))
    		{
    			return result;
    		}
    	}
    
        return defaultValue;
    }
