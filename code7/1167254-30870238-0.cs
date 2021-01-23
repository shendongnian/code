	string s = "2020-12-27 20:00:00";
	DateTime dt;
	if(DateTime.TryParseExact(s, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt))
	{
		// 27.12.2020 20:00:00
	}
