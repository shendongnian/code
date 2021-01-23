    void Main()
    {
    	double input = 3.213112134;
    	string result = input.ToGlobalizationString("F4").Dump();
    }
    
    public static class Extensions
    {
    	public static string ToGlobalizationString(this double input, string format)
    	{
    		return input.ToString(format, CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name));
    	}
    }
