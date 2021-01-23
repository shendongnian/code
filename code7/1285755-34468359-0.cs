    static void Main(string[] args)
    {
        Thread.Sleep(DateTime.Today.AddDays(1) - DateTime.Now);
        Console.WriteLine("It's about midnight, I go to sleep");
    }
