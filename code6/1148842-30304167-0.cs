    // Ensures the string has 9 digits and optionally starts with a "+"
    Regex regex = new Regex(@"^(\+)?([0-9]{9})");
    string input;
    
    while (!regex.IsMatch(input))
    {
        Console.Write("Please enter your phone number: ");
        input = Console.ReadLine();
    }
