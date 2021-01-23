    string someString = "ABC";
    DateTime someDate;
    try
    {
        someDate = DateTime.Parse(someString);
    }
    catch
    {
        // someString must not have been a valid DateTime!
        Console.WriteLine($"Hey, {someString} is not a valid DateTime!"); 
    }
    // Code continues executing because the exception was "caught"
