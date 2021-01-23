	int i = 20140820;
	DateTime dt;
	if(DateTime.TryParseExact(i.ToString(), "yyyyMMdd", 
                              CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt))
	{
		Console.WriteLine(dt);
	}
