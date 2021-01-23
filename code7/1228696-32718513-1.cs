    public static class DecimalExtenstions
    {
    	public static string Display(this decimal? value) 
    	{
    		return value.HasValue ? value.ToString(): "N/A";
    	}
    }
