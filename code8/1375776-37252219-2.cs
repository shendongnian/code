    public static void Main()
    {
        var syncTask2 = Task.Factory.StartNew(() =>
        {
            for (int ctr = 1; ctr <= 10; ctr++)
                Console.WriteLine(ctr.ToString() + "2");
        });           
        var syncTask3 = Task.Factory.StartNew(() =>
        {
            for (int ctr = 1; ctr <= 10; ctr++)
            Console.WriteLine(ctr.ToString() + "3");
        });
        Task.WaitAll(syncTask2, syncTask3) // wait synchronously
        var syncTask1 = Task.Factory.StartNew(() =>
        {
            for (int ctr = 1; ctr <= 10; ctr++)
                Console.WriteLine(ctr.ToString() + "1");
        }).Wait(); // wait syncronously for task 1 after 2 and 3 finishes
      
        Console.ReadLine();
    }
