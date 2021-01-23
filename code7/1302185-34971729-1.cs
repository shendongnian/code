    Console.WriteLine("Please enter a date.");
    string dateString = Console.ReadLine();
    DateTime dateValue;
    // prompt user for target date here
    if (DateTime.TryParse(dateString, out dateValue))
    {
        Console.WriteLine("You have entered a valid date for a leap year!");
    }
    else
    {
        Console.WriteLine("The provided date could not be parsed, or is not a valid date for a leap year.");
    }
