    try
    {
        string s = null;
        ProcessString(s);
    }
    // Most specific:
    catch (ArgumentNullException e)
    {
        Console.WriteLine("{0} First exception caught.", e);
    }
    // Least specific:
    catch (Exception e)
    {
        Console.WriteLine("{0} Second exception caught.", e);
    }
