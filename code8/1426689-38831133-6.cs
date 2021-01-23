    public static class NumberExtensions
    {
    	// <= C#6
    	public static bool IsNumeric(this string str)
    	{
    		float f;
    		return float.TryParse(str, out f);
    	}
    
    	// C# 7+
    	public static bool IsNumeric(this string str) => float.TryParse(str, out var _);
    }
    // ... elsewhere
    "123".IsNumeric();     // true
    "abc".IsNumeric();     // false, etc
    "-1.7e5".IsNumeric();  // true
