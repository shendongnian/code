    public static string FormatNumber(this int num)
    {
    	if (num >= 100000000)
    	{
    		return ((num >= 10050000 ? num-50000 : num) / 1000000D).ToString("0.#M");
    	}
    	if (num >= 10000000)
    	{
    		return ((num >= 10500000 ? num - 50000 : num) / 1000000D).ToString("0.#M"); .
    	}
    	if (num >= 1000000)
    	{
    		return ((num >= 1005000 ? num-5000 : num) / 1000000D).ToString("0.##M"); 
    	}
    	if (num >= 100000)
    	{
    		return ((num >= 100500 ? num - 500 : num) / 1000D).ToString("0.k"); .
    	}
    	if (num >= 10000)
    	{
    		return ((num >= 10550 ? num - 50 : num) / 1000D).ToString("0.#k"); 
    	}
    	if (num >= 1000)
    	{
    		return ((num >= 1550 ? num - 5 : num) / 1000D).ToString("0.##k"); 
    	}
    
    	return num.ToString("#,0");
    }
