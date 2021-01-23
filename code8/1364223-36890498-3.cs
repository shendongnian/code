    int minutes;
    bool parsed = int.TryParse(input, out minutes);
    if (parsed)
    {
        // your if statements
    }
    else
    {
        Console.WriteLine("That is not valid input");
    }
