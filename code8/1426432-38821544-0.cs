    ServerConnection.DoWorkCompleted += (sender, args) => 
    {
        Console.WriteLine($"DoWork result: {args.Result}");
    };
    ServerConnection.DoWorkAsync(); // void, the result is provided through event handler
