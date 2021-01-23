    int sin;
    Console.Write("Please enter sin number: ");
	string input = Console.ReadLine();
    bool parse_ok=  int.TryParse(input,out sin);
	
    while (!parse_ok || digits.Length != 9 || sin < 100000000 )
	{
        Console.WriteLine("Error invalid entry");
		Console.Write("Please enter sin number: ");
    	input = Console.ReadLine();  
		bool parse_ok=  int.TryParse(input,out sin);
	}	;
