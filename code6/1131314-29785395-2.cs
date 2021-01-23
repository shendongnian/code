	public static string SubstringAfter(string s, string after = "ABC")
	{
		var result = s.Remove(0, after.Length);
		return result;
	}
