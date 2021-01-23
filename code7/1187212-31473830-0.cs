	var source = new [] { "23.06.2015", "", "01.07.2014", "" };
	
	Func<string, DateTime?> parse = s =>
	{
		DateTime result;
		if (DateTime.TryParseExact(
			s,
			"dd.MM.yyyy",
			System.Globalization.CultureInfo.CurrentCulture,
			System.Globalization.DateTimeStyles.AssumeLocal,
			out result))
		{
			return result;
		}
		return null;
	};
	
	var query =
		from s in source
		orderby parse(s) descending
		select s;
