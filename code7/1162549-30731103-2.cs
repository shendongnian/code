    try
    {
        await connection.Start().ConfigureAwait(false);
        Console.WriteLine("Connected");
    }
    catch (Exception e)
    {
        Console.WriteLine("There was an error opening the connection: {0}", e);
    }
