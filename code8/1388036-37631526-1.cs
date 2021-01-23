    public float?[] getPricesOfGivenProducts(string[] lookupProducts)
    {
    	var idsAndPrices = myReadings.ToDictionary(r => r.ProductId, r => r.Price);
    	
    	float?[] prices = new float?[lookupProducts.Length];
    
    	for (int i = 0; i < lookupProducts.Length; i++)
    	{
    		string id = lookupProducts[i];
    		if (idsAndPrices.ContainsKey(id))
    		{
    			prices[i] = idsAndPrices[id];
    		}
    		else
    		{
    			prices[i] = null;
    		}
    	}
    	return prices;
    }
