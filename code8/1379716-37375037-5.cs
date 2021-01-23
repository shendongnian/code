    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = Enumerable.Range(1, 100);
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine("{0} is even", number);
                }
            }
            Console.Read();
        }
    }
