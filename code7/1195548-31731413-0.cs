    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executing...");
            var numOfTasks = 50;
            var tasks = new List<Task>();
            for (int i = 0; i < numOfTasks; i++)
            {
                var iTask = Task.Run(() =>
                {
                    var counter = Interlocked.Increment(ref _Counter);
                    Console.WriteLine(counter);
                    if (counter == numOfTasks - 1)
                    {
                        Console.WriteLine("Waiting {0} ms", 5000);
                        Task.Delay(5000).Wait(); // to simulate a longish running task
                    }
                    _State.AddOrUpdate(counter, "Updated Yo!", (k, v) =>
                    {
                        throw new InvalidOperationException("This shouldn't occure more than once.");
                    });
                });
                tasks.Add(iTask);
            }
            Task.WhenAll(tasks)
                .ContinueWith(t =>
                {
                    var longishState = _State[numOfTasks - 1];
                    Console.WriteLine(longishState);
                    Console.WriteLine("Complete. longishState: " + longishState);
                });
            Console.ReadKey();
        }
        static int _Counter = -1;
        static ConcurrentDictionary<int, string> _State = new ConcurrentDictionary<int, string>();
    }
