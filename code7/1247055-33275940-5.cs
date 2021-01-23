    public static void Main()
    {
        Console.WriteLine("Starting.");
        for (int i = 0; i < 4; ++i)
        {
            int j = i;
            Task.Run(() => Console.WriteLine(j));
        }
        Console.WriteLine("Finished. Press <ENTER> to exit.");
        Console.ReadLine();
    }
