    class Program
    {
        static void Main(string[] args)
        {
            // first run with default number of threads
            Parallel.For(0, 10, i => DoSomething(i));
            Console.ReadLine();
            // now run with fewer threads...
            Parallel.For(0, 10, new ParallelOptions{ 
                                      MaxDegreeOfParallelism = 2 
                                    }, i => DoSomething(i));
            Console.ReadLine();
        }
        
        static void DoSomething(int par)
        {
            int i = Environment.CurrentManagedThreadId;
            // int i = Thread.ManagedThreadId;  -- .NET 4.0 and under
            Thread.Sleep(200);
            Console.WriteLine("Test: "+ par.ToString() + 
                              ", Thread :" + i.ToString());
        }
    }
