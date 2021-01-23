	Func<string, DateTime?> tryParse = t =>
	{
		DateTime output;
		if (DateTime.TryParseExact(
			t,
			new [] { "h:mmtt MM/dd/yyyy" },
			System.Globalization.CultureInfo.CurrentCulture,
			System.Globalization.DateTimeStyles.AssumeLocal,
			out output))
		{
			return output;
		}
		return null;
	};
	
	var dt1 = tryParse("12:35pm 02/13/2016");
	var dt2 = tryParse("1:45pm 02/14/2016");
	
	TimeSpan? ts = null;
	if (dt1.HasValue && dt2.HasValue)
	{
		ts = dt2.Value.Subtract(dt1.Value);
	}
	
	if (ts.HasValue)
	{
		Console.WriteLine(
			String.Format(
				"{0} hours & {1} minutes",
				ts.Value.Hours,
				ts.Value.Minutes));
	}
