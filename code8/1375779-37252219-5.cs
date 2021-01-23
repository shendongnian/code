    public static void Main()
    {
        var syncTask2 = Task.Factory.StartNew(() =>
        {
            for (int ctr = 1; ctr <= 10; ctr++)
                Console.WriteLine(ctr.ToString() + "2");
        }).Wait(); // wait for second task finishing syncronously          
        var syncTask3 = Task.Factory.StartNew(() =>
        {
            for (int ctr = 1; ctr <= 10; ctr++)
            Console.WriteLine(ctr.ToString() + "3");
        }).Wait(); //// wait for third task finishing syncronously after second
        var syncTask1 = Task.Factory.StartNew(() =>
        {
            for (int ctr = 1; ctr <= 10; ctr++)
                Console.WriteLine(ctr.ToString() + "1");
        }).Wait(); // wait for first task finishing syncronously after second and third          
      
        Console.ReadLine();
    }
