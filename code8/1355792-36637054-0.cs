    class Program
    {
        static void Main(string[] args)
        {
            f(1, 5, ascending: true);
            f(1, 10, ascending: false);
            Console.ReadLine();
        }
        private static void f(int start, int count, bool ascending)
        {
            var indices = Enumerable.Range(start, count);
            if (!ascending) indices = indices.Reverse();
            foreach (int index in indices)
            {
                for (int i = 1; i <= index; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine(2 * index);
            }
        }
    }
