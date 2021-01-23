    while (spaces > 2)
    {
        Console.WriteLine("You entered more than three words! Try again!");
        s = Console.ReadLine();
        spaces = s.Count(char.IsWhiteSpace);
    }
