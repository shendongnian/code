    class Program
    {
        static void Main(string[] args)
        {
            var threads = Enumerable.Repeat(new Action(() => Console.WriteLine(Singleton.Instance.guid)), 10);
            Parallel.ForEach(threads, t => t());
            Console.Read();
        }
    }
