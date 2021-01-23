    int number = 20;
	string numericString = number.ToString();
	
	var result = 0;
	if(int.TryParse(numericString, out result)) 
	{
		Console.WriteLine("This is a valid int: {0}", result);
	}
	else 
	{
	    Console.WriteLine("This string is not a valid int: {0}", numericString);
	}
