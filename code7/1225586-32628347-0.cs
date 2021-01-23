    public static class MyExtensions
    {
    	public static int IndexOfNonWhitespace(this string source, int startIndex = 0)
    	{
    		if (startIndex < 0) throw new ArgumentOutOfRangeException("startIndex");
    		if (source != null)
    			for (int i = startIndex; i < source.Length; i++)
    				if (!char.IsWhiteSpace(source[i])) return i;
    		return -1;
    	}
    }
