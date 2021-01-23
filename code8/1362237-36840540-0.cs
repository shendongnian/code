    class Program
    {
        static void Main(string[] args)
        {
            int sum = Enumerable.Range(0, 10).Where(i => i % 3 == 0).Sum();
            Console.WriteLine(sum);
        }
    }
