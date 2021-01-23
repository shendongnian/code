    int sin;
    Console.Write("Please enter sin number: ");
	string input = Console.ReadLine();
    bool parse_ok=  int.TryParse(input,sin);
	
    while (!parse_ok || digits.Length != 9 )
	{
        Console.WriteLine("Error invalid entry");
		Console.Write("Please enter sin number: ");
    	input = Console.ReadLine();  
		bool parse_ok=  int.TryParse(input,sin);
	}	;
