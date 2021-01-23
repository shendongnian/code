    Main(...)
    {
        // ...
        Console.WriteLine("Please enter a username");
        var user = Console.ReadLine();
        Console.WriteLine("Please enter your password");
        var password = Console.ReadLine();
        var auth = new Authentication();
        if(auth.Authenticate(user, password))
        { // do what you need to do ;) }
    }
