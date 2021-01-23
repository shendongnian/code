    static void Main(string[] args)
    {
         Console.WriteLine("----Calling my method----");
         timer.Start();
         Console.ReadLine();
    }
    private static void MyMethod()
    {
        Console.WriteLine("*** Method is executed at {0} ***", DateTime.Now);
        Console.ReadLine();
    }
