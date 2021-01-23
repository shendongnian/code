    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(0, 10, i => DoSomething(i));
            Console.ReadLine();
        }
        
        static void DoSomething(int par)
        {
            int i = Environment.CurrentManagedThreadId;
            // int i = Thread.ManagedThreadId;  -- .NET 4.0 and under
            Console.WriteLine("Test: "+ par.ToString() + i.ToString());
        }
    }
