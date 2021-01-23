    static async Task baseTask()
    {
        Console.WriteLine("Starting long method.");
        await Task.Delay(1000);
        Console.WriteLine("Finished long method.");
    }
