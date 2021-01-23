    //sample input = 0123456789,0123456789,0123456789
    if (Regex.IsMatch(input, @"\d{10},"))
    {
        Console.WriteLine("comma");
    }
    else if (Regex.IsMatch(input, @"\d{10}\s"))
    {
        Console.WriteLine("White space");
    }
