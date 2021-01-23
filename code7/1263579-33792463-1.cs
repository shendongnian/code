    try
    {
        Date date = new Date(day, month, year);
        Console.WriteLine("{0}/{1}/{2}", date.Day, date.Month, date.Year);
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine(ex.Message);
    }
