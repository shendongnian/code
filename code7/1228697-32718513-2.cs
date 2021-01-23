    public static class DecimalExtensions
    {
    	public static string Display(this decimal? value) 
    	{
    		return value.HasValue ? value.ToString(): "N/A";
    	}
    }
