    private async void SayHelloTwice()
    {
        // Start the tasks, don't wait
        Task<string> firstHello = PrintTask();
        Task<string> secondHello = PrintTask();
        // Wait for results
        string firstResult = await firstHello;
        string secondResult = await secondHello;
        // Print results
        Console.WriteLine(firstResult);
        Console.WriteLine(secondResult);
    }
