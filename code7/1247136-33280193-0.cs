	string s = "19/12/36 12:00:00 ص";
	DateTime dt;
	if(DateTime.TryParseExact(s, "dd/MM/yy hh:mm:ss tt", CultureInfo.GetCultureInfo("ar-sa"),
							  DateTimeStyles.None, out dt))
	{
		Console.WriteLine(dt);
	}
