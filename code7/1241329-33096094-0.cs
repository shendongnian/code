	string s = "01.09.2015";
	DateTime dt;
	if(DateTime.TryParseExact(s, "dd.MM.yyyy", CultureInfo.GetCultureInfo("en-CA"),
							  DateTimeStyles.None, out dt))
	{
		// 1 September 2015
	}
