    static async Task DoHeavyWork(int idx, int max)
    {
        for (long i = 1; i <= max; ++i)
        {
            Console.WriteLine($"Task {idx} - {i}");
            await Task.Delay(200);
        }
    }
