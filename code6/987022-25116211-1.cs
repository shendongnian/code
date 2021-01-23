    Console.WriteLine("how old are you?");
    string input = Console.ReadLine().Trim();
    bool success = int.TryParse(input, out results);
 
    if ( success )
    {
        Console.WriteLine("{0} is an integer", input); // results has the correct value                
    }
    else
    {
        Console.WriteLine("{0} is not an integer", input);                 
    }
