    public static decimal ParseCurrencyWithSymbol(string input)
    {
    	var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures)
    		.GroupBy(c=> c.NumberFormat.CurrencySymbol)
    		.ToDictionary(c=> c.Key, c=>c.First());
    	
    	
    	var culture = cultures.FirstOrDefault(c=>input.Contains(c.Key));
    	
    	decimal result = 0;
    	if(!culture.Equals(default(KeyValuePair<string,CultureInfo>)))
    	{
    		result = decimal.Parse(input, NumberStyles.Currency | NumberStyles.AllowDecimalPoint, culture.Value);
    	}
    	else
    	{
    		if( !decimal.TryParse(input, out result))
    		{
    			throw new Exception("Invalid number format");
    		}
    	}
    	
    	return result;
    }
