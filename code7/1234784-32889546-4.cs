	public static string GetBlacklistRegexString(string[] blacklist)
	{
		//It seems that this service only support engligh natively, to check later
		var ps = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));
		//Using a StringBuilder for ease of use and performance,
		//even though it's not easy on the eye :p
		StringBuilder sb = new StringBuilder().Append(@"\b(");
		//We're just going to make a unique regex with all the words
		//and their plurals in a list, so we're looping here
		foreach (var word in blacklist)
		{
			//Using a dot wasn't careful indeed... Feel free to replace
			//"\W" with anything that does it for you. It will match
			//any non-alphanumerical character
			var regexPlural = ps.Pluralize(word).Replace(" ", @"\W");
			var regexWord = word.Replace(" ", @"\W");
			sb.Append(regexWord).Append('|').Append(regexPlural).Append('|');
		}
		sb.Remove(sb.Length - 1, 1); //removing the last '|'
		sb.Append(@")\b");
		return sb.ToString();
	}
