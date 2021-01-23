    Console.WriteLine("Please enter a date.");
    string input = Console.ReadLine();
    DateTime date;
    // prompt user for target date here
    if (DateTime.TryParse(input, out date))
    {
        Console.WriteLine("You have entered a valid date for a leap year!");
    }
    else
    {
        Console.WriteLine("The provided date could not be parsed, or is not a valid date for a leap year.");
    }
