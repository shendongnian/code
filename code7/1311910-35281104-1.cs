    static void Main(string[] args)
    {
        callCount().Wait();
    }
    static void count()
    {
        for (int i = 0; i < 5; i++)
        {
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("count loop: " + i);
        }
    }
    static async Task callCount()
    {
        Task task = new Task(count);
        task.Start();
        for (int i = 0; i < 3; i++)
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Writing from callCount loop: " + i);
        }
        Console.WriteLine("just before await");
        await task;
        Console.WriteLine("callCount completed");
    }
