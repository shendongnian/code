	public static string SubstringAfter(string s, string after)
	{
		var result = s.Substring(s.IndexOf(after) + after.Length);
		return result;
	}
