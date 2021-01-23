    try
    {
        Date date = new Date(day, month, year);
    }
    catch(ArgumentOutOfRangeException exc)
    {
        Console.WriteLine(exc.Message);
    }
