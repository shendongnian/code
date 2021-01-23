    public static void oddThread()
    {
        for (int i = 1; i < 10; i +=2)
        {
            evenReady.WaitOne();
            Console.WriteLine(i);
            oddReady.Set();
        }
    }
    public static void evenThread()
    {
        for (int i = 0; i < 10; i += 2)
        {
            oddReady.WaitOne();
            Console.WriteLine(i);
            evenReady.Set();
        }
    }
