    private static void Main()
    {
        SetupUnobservedTaskExceptionHandling();
        Task.Factory.StartNew(() =>
        {
            var counter = 5;
            for (; counter > 0; counter--)
            {
                Console.WriteLine(counter);
                Thread.Sleep(1000);
            }
            throw new InvalidCastException("I threw up!");
        });
        Thread.Sleep(10000);
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.ReadLine();
    }
