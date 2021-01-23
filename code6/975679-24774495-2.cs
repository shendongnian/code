	string s = "22/11/2009";
	DateTime dt;
	if(DateTime.TryParseExact(s, "dd/MM/yyyy", CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt))
	{
		Console.WriteLine(dt); // 22.11.2009 00:00:00
	}
