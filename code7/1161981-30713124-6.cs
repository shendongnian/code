    class Program
    {
        const double test = 5.5;
        static void Main(string[] args)
        {
            double i = Double.Parse(args[0]);
            Console.WriteLine(test * i * 1.5);
        }
    }
