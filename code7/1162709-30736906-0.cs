    static void Main(string[] args)
    {
        int threadsNumber = 0;
        Console.WriteLine("Enter the number of threads: ");
        while ((Int32.TryParse(Console.ReadLine(), out threadsNumber) == false) || (threadsNumber <= 0))
        {
            Console.WriteLine("You need to enter a positive number!");
        }
        Console.Clear();
        BlockingCollection<int> queue = new BlockingCollection<int>();
        Thread[] threadMas = new Thread[threadsNumber];
        for (int i = 0; i < threadsNumber; i++)
        {
            threadMas[i] = new Thread(ProcessQueue);
            threadMas[i].Start(queue);
        }
        queue.Add(5);
        queue.Add(6);
        queue.Add(7);
        queue.Add(8);
        queue.Add(9);
        queue.Add(10);
        queue.Add(11);
        queue.Add(1);
        queue.CompleteAdding(); // Use this to signal that no more items will be added to the queue.
    }
    private static void ProcessQueue(object data)
    {
        BlockingCollection<int> queue = (BlockingCollection<int>)data;
        foreach (var num in queue.GetConsumingEnumerable()) // this will automatically exit the loop once CompleteAdding is called.
        {
            BigInteger bigInt = Factorial.FactTree(num); //factorical
            Writer.WriteToFile(num + " factorial: " + bigInt, "result.txt"); //write to file
        }
    }
