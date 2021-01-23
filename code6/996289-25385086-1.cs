	string s = "Tue Feb 4 00:00:00 UTC+0100 2014";
	DateTime dt;
	if(DateTime.TryParseExact(s, "ddd MMM d HH:mm:ss 'UTC+0100' yyyy", 
                              CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt))
	{
		Console.WriteLine(dt);
	}
