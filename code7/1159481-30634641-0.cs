    public static void Main()
	{
		string str;
		
		str = Console.ReadLine();
		
		decimal dec = decimal.Parse(str, NumberStyles.Any, CultureInfo.InvariantCulture);
		double db = double.Parse(str, NumberStyles.Any, CultureInfo.InvariantCulture);
		
		Console.WriteLine(dec.ToString("F2", CultureInfo.InvariantCulture));
		Console.WriteLine(db.ToString("F2", CultureInfo.InvariantCulture));
		
		return;
	}
