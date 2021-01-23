	public static string Center(string str, int length)
	{
		if (string.IsNullOrWhiteSpace(str))
		{
			return new String(' ',length);
		}
		if (str.Length >= length)
		{
			return str;
		}
		var halfDiff = (length - str.Length)/2.0;
		return string.Format("{0}{1}", new String(' ', (int) Math.Floor(halfDiff)), str) ;
	}
