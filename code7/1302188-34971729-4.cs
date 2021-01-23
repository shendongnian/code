    Console.WriteLine("Please enter a date.");
    string dateString = Console.ReadLine();
    DateTime dateValue;
    if (DateTime.TryParse(dateString, out dateValue))
    {
        // Hooray, your input was recognized as having a valid date format,
        // and is a valid date! dateValue now contains the parsed date
        // as a DateTime.
        Console.WriteLine("You have entered a valid date!");
    }
    else
    {
        // Aww, the date was invalid.
        Console.WriteLine("The provided date could not be parsed.");
    }
