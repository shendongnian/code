    public string LinearSearchMultiple(int productCode)
    {
    	var productCodes = string.Empty;
    
    	for (int i = 0; i < bottles.Length; i++)
    	{
    		var bottle = bottles[i];
    		if(bottle==null)
    		{
    			continue;
    		}
    		if (bottle.Product_code == productCode)
    		{
    			productCodes += bottle.ToString() + "\n";
    		}
    	}
    
    	return productCodes;
    }
