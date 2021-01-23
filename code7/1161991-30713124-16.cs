    class Program
    {
        const int test = 5;
        static void Main(string[] args)
        {
            int i = Int32.Parse(args[0]);
            Console.WriteLine(test * i * 2);
        }
    }
