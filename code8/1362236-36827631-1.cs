    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int starting = 0; starting < 10; starting += 3)
            {
                sum += starting;
            }
            Console.WriteLine("Sum: [{0}]", sum);
        }
    }
