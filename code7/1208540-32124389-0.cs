	void Main()
	{
		DescribeIt(System.Globalization.CultureInfo.InstalledUICulture);
		DescribeIt(System.Globalization.CultureInfo.CurrentUICulture);
		DescribeIt(new System.Globalization.CultureInfo("en-US"));
		DescribeIt(new System.Globalization.CultureInfo("fr-FR"));
	}
	
	public void DescribeIt(System.Globalization.CultureInfo ci)
	{
		Console.Write("Culture: {0}", ci);
		Console.Write(@"; NumberFormat.NumberGroupSeparator: ""{0}""", 
			ci.NumberFormat.NumberGroupSeparator);
		Console.Write(@"; NumberFormat.NumberDecimalSeparator: ""{0}""", 
			ci.NumberFormat.NumberDecimalSeparator);
		Console.WriteLine();		
	}
