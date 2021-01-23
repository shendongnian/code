	public static List<string> GetBetweenAll(this string main, string start, string finish, bool preserve = false,  int index = 0)
	{
		List<string> matches = new List<string>();
		Match gbMatch = new Regex(Regex.Escape(start) + "(.+?)" + Regex.Escape(finish)).Match(main, index);
		while (gbMatch.Success)
		{
			matches.Add((preserve ? start : string.Empty) + gbMatch.Groups[1].Value + (preserve ? finish : string.Empty));
			gbMatch = gbMatch.NextMatch();
		}
		return matches;
	}
	public static string[] getBetweenAllBackwards(this string main, string strstart, string strend, bool preserve = false)
	{
		List<string> all = Reverse(main).GetBetweenAll(Reverse(strend), Reverse(strstart), preserve);
		for (int i = 0; i < all.Count; i++)
		{
			all[i] = Reverse(all[i]);
		}
		return all.ToArray();
	}
	public static string Reverse(string s)
	{
		char[] charArray = s.ToCharArray();
		Array.Reverse(charArray);
		return new string(charArray);
	}
