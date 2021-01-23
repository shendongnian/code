    private async void SayHelloTwice()
    {
        string[] results = await Task.WhenAll(
            PrintTask(),
            PrintTask());
    
        Console.WriteLine(results[0]);
        Console.WriteLine(results[1]);
    }
