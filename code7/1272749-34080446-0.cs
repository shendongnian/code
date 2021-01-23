    public static class Extensions
    {
    	public static Tuple<string, string> SplitString(this string str, int splitAt)
    	{
    		var lhs = str.Substring(0, splitAt);
    		var rhs = str.Substring(splitAt);
    		return Tuple.Create<string, string>(lhs, rhs);
    	}	
    }
