    // valid Date
	DateTime goodDate;
	if (DateTime.TryParse("2000-02-02", out goodDate))
	{
	    Console.WriteLine(goodDate);
	}
	// not a date
	DateTime badDate;
	if (DateTime.TryParse("???", out badDate))
	{
	    Console.WriteLine(badDate);
	}
	else
	{
	    Console.WriteLine("Invalid");
	}
