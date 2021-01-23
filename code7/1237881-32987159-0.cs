    public static class StringExtensions
    {
    	public static string ReplaceFirst(this string source, char oldChar, char newChar)
    	{
    		if (string.IsNullOrEmpty(source)) return source;
    		int index = source.IndexOf(oldChar);
    		if (index < 0) return source;
    		var chars = source.ToCharArray();
    		chars[index] = newChar;
    		return new string(chars);
    	}
    }
