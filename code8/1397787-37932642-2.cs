    static async Task Loop1Async()
    {
        for (int i = 0; i < 500; i++)
        {
            Console.WriteLine("Loop 1 : " + i);
            await Task.Yield();
        }
    }
    static async Task Loop2Async()
    {
        for (int i = 0; i < 500; i++)
        {
            Console.WriteLine("Loop 2 : " + i);
            await Task.Yield();
        }
    }
