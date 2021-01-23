    public static class Extensions
    {
    	public static IEnumerable<string> RegexReplace (this IEnumerable<string> strings, Regex regex, string replacement)
    	{
    		foreach (var s in strings)
    		{
    			yield return regex.Replace(s, replacement);
    		}
    	}
    }
