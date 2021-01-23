    const string input = "[inputs are below]";
	var style = System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign;
	var culture = System.Globalization.CultureInfo.InvariantCulture;
	System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
	s.Reset();
	s.Start();
	for (int i=0; i<10000000; i++)
	{
		decimal.Parse(input, style, culture);
	}
	s.Stop();
	Console.WriteLine(s.Elapsed.ToString());
	s.Reset();
	s.Start();
	for (int i=0; i<10000000; i++)
	{
		ParseDecimal(input);
	}
	s.Stop();
	Console.WriteLine(s.Elapsed.ToString());
