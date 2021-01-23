    var client = new MyService();
    var results = client.DoSomething();
    
    if (results.IsSuccess)
    {
        Console.WriteLine("It worked");
    }
    else
    {
        Console.WriteLine($"Oops: {results.ErrorDetails}");
    }
