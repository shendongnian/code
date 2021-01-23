    static void Main(string[] args)
    {
        Console.WriteLine("Hello world");
        new Thread(DoSomethingElse).Start();            
        Console.ReadLine();
    }
    private static void DoSomethingElse()
    {
        while (true)
        {
            Thread.SpinWait(100);
        }
    }
