    try
    {
        accounts.Add(username, password);
    }
    catch (ArgumentException)
    {
        Console.WriteLine("Username is taken!");
    }
