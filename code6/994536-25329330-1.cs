    IDataReader reader = null;
    try
    {
        reader = dbcmd.ExecuteReader();
    }
    catch (InvalidOperationException ex2)
    {
        Console.WriteLine(ex2.Message);
    }
