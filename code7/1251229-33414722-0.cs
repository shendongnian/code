    private static int printMessage(object c)
    {
        int ctr = (int)c;
        for (ctr = 0; ctr <= 1000000; ctr++)
        { }
        return ctr;
    }
    public static void Main()
    {
        Task<int> t = Task.Factory.StartNew(new Func<object, int>(printMessage), 1);
        t.Start();
        t.Wait();
        Console.WriteLine("The sum is: " + t.Result);
        Console.ReadLine();
    }
