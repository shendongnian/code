    try
    {
        // do stuff...
    }
    catch ( Exception e1 )
    {
        // do stuff with e1...
        Console.WriteLine(e1.Number + " - " + e1.Message);
    }
    catch ( AnotherException e2 )
    {
        // do stuff with e2...
        Console.WriteLine(e2.Number + " - " + e2.Message);
    }
    etc...
