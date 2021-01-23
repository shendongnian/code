    public static class NumberExtensions
    {
    	public static bool IsNumeric(this string str)
    	{
    		float f;
    		return float.TryParse(str, out f);
    	}
    }
    // ... elsewhere
    "123".IsNumeric();  // true
    "abc".IsNumeric();  // false, etc
