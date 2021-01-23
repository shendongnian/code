	string s = "3/31/2015";
	DateTime dt;
	if(DateTime.TryParseExact(s, "M/dd/yyyy", CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt))
	{
		Console.WriteLine(dt); // 31/03/2015 00:00:00
	}
