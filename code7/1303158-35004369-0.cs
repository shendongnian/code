    Console.Write("Please enter the name of the student: ");
    //here I made the input to turn into Capitals
    name = Console.ReadLine().ToUpper(); 
    if (Regex.IsMatch(name, @"^[a-zA-Z]+$")) { // If letters only
     // Do something
    }else{
     Console.WriteLine("Name must contain letters only");
    }
    Console.Write("Please enter their student number: ");
    // here I set a condition order to continue. First the input must be integer and second it must be positive
    while (!int.TryParse(Console.ReadLine(), out id)||id<0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("The value must be of integer type, try again: ");
        Console.ResetColor();
    }
