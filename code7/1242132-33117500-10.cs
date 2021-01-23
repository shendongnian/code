    foreach (var figure in figures)
    {
        if (Regex.IsMatch(figure, @"^\d+\.\d+$"))
        {
            Console.WriteLine("{0}: Floatingpoint Number", figure);
        }
        else if (Regex.IsMatch(figure, @"^\d+$"))
        {
            Console.WriteLine("{0}: Integer Number", figure);
        }
        else
        {
            Console.WriteLine("{0}: No Number", figure);
        }
    }
