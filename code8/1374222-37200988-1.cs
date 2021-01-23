    try 
    {
        var list = await obj.GetAllReports(token, username);
        ...
    }
    catch (RequestException ex)
    {
        Console.WriteLine(ex.Message);
    }
