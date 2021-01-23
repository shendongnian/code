    string line = @"4000 BCE&#8211;5000 BCE and 600 CE&#8211;650 CE";
    Regex RxCode = new Regex(@"&#([0-9]+);");
    string lineNew = RxCode.Replace(
    	line,
    	delegate( Match match )	{
    		return "" + (char)Convert.ToInt32( match.Groups[1].Value);
    	}
    );
    Console.WriteLine( lineNew );
