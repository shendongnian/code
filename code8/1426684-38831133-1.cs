    public static class NumberExtensions
    {
    	public static bool IsNumeric(this string str)
    	{
    		int i;
    		return int.TryParse(str, out i);
    	}
    }
    // ... elsewhere
    "123".IsNumeric();  // true
    "abc".IsNumeric();  // false, etc
