	public static int EndIndexOf(this string source, string value)
	{
		int index = source.IndexOf(value);
		if (index >= 0)
		{
			index += value.Length;
		}
		
		return index;
	}
