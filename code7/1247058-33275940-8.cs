    public static void Main()
    {
        Console.WriteLine("Starting.");
        for (int i = 0; i < 4; ++i)
            Task.Run(() => Console.WriteLine(i));
        Console.WriteLine("Finished. Press <ENTER> to exit.");
        Console.ReadLine();
    }
