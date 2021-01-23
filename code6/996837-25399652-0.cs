	int i = 20140820;
	string s = i.ToString();
	DateTime dt;
	if(DateTime.TryParseExact(s, "yyyyMMdd", CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt))
	{
		Console.WriteLine(dt);
	}
