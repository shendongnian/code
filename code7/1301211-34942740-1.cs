    var item = Console.ReadLine();
    int input;
    if (int.TryParse(item, out input))
    {
    	// here you got item as int in input variable.
    	// do your stuff.
    	Console.WriteLine("OK");
    }
    else
    	Console.WriteLine("Entered value is invalid");
    
    Console.ReadKey();
