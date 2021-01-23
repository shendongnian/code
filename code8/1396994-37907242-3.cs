    if (!UserExists(username))
    {
        CreateUser(username, password);
        Console.WriteLine("User {0} created", username);
    }
    else
    {
        bool loginOk = Verify(username, password);
        Console.WriteLine("Login ok?: {0}", loginOk);
    }
