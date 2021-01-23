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
        string userInput = null;
        do
        {
            Console.WriteLine("Enter a number: ");
            userInput = Console.ReadLine();
            if (userInput != "stop") {
                queue.Add(int.Parse(userInput)); // These numbers get process by the threads in parallel.
            }
        } while (userInput != "stop");
        queue.CompleteAdding(); // Use this to signal that no more items will be added to the queue.
        // Now the main thread exits.
        // But the program stays alive until the other threads finish
        // clearing the queue.
    }
    private static void ProcessQueue(object data)
    {
        BlockingCollection<int> queue = (BlockingCollection<int>)data;
        foreach (var num in queue.GetConsumingEnumerable()) // This will automatically exit the loop once CompleteAdding is called and the queue is empty.
        {
            BigInteger bigInt = Factorial.FactTree(num); //factorical
            Writer.WriteToFile(num + " factorial: " + bigInt, "result.txt"); //write to file
        }
    }
