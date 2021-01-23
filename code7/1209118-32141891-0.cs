	public static IEnumerable<int> GetUnicodeCodePoints(this string s)
	{
		for (int i = 0; i < s.Length; i++)
		{
			int unicodeCodePoint = char.ConvertToUtf32(s, i);
			if (unicodeCodePoint > 0xffff)
			{
				i++;
			}
			yield return unicodeCodePoint;
		}
	}
