    class MasodmegoldResult
    {
    	public string ErrorMessage { get; set; }
    	public double Value1 { get; set; }
    	public double Value2 { get; set; }
    
    	public static MasodmegoldResult Error(string message)
    	{
    		return new MasodmegoldResult()
    		{
    			ErrorMessage = message,
    			Value1 = double.NaN,
    			Value2 = double.NaN,
    		}
        }
    }
