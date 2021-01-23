	Console.Write("What is the price?"); 
	price = decimal.Parse(Console.ReadLine()); // you're already parsing the user-input it
    // this is somewhat problematic, because if the user enters "foo" instead of "123" the
    // attempt to parse the input will fail
	double pricenumber;
	while (!double.TryParse(price, out pricenumber)) // the variable "price" already contains
    // a parsed decimal. That's what you did some lines above. "TryParse" expects a string to
    // be parsed whereas you're committing the parsed decimal
	{
		Console.WriteLine("You've not entered a price.\r\nPlease enter a price");
		price = decimal.Parse(Console.ReadLine());
	}
