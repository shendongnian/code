    class Program
    {
        public static void Main(string[] args)
        { 
            Console.WriteLine(SynchronizationContext.Current == null ? "NoContext" : "Context!");
        }
    }
