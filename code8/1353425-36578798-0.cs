    class Program
    {
        static void Main(string[] args)
        {
            List<int> allElements = new List<int>();
            for (int i = 0; i <= 9; i++)
                allElements.Add(i);
            Random rnd = new Random();
            Queue<int> myQueue = new Queue<int>(allElements.OrderBy(e => rnd.NextDouble()));
            while (myQueue.Count > 0)
            {
                int currentInt = myQueue.Dequeue();
                Console.WriteLine(currentInt);
            }
            Console.ReadLine();
        }
    }
