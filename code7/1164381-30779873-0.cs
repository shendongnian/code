    string s = "11 June 201512.00AM";
	DateTime dt;
	if(DateTime.TryParseExact(s, "dd MMMM yyyyhh.mmtt", CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt))
	{
		Console.WriteLine(dt); // 11.06.2015 00:00:00
	}
