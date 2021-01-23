    double outcome = 0;
    bool valid = false;
    while (!valid)
    {
        Console.WriteLine("Enter amount: ");
        string inValue = Console.ReadLine();
        if (double.TryParse(inValue, out outcome) == false)
        {
            Console.WriteLine("Initial value must be of the type double");
            Console.WriteLine("\nPlease enter the number again: ");
        }
        else if (outcome < 0)
        {
            Console.WriteLine("Initial value must be of at least a value of zero");
            Console.WriteLine("\nPlease enter the number again: ");
        }
        else
        {
            valid = true;
        }
    }
    return outcome;
