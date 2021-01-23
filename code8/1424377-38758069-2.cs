    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetRandomDouble(double.MinValue,double.MaxValue));
            Console.WriteLine(GetRandomDouble(double.MinValue, double.MaxValue));
            Console.WriteLine(GetRandomDouble(double.MinValue, double.MaxValue));
            Console.WriteLine(GetRandomDouble(double.MinValue, double.MaxValue));
            Console.WriteLine(GetRandomDouble(double.MinValue, double.MaxValue));
            Console.WriteLine(GetRandomDouble(double.MinValue, double.MaxValue));
            Console.WriteLine(GetRandomDouble(double.MinValue, double.MaxValue));
            Console.WriteLine(GetRandomDouble(double.MinValue, double.MaxValue));
            Console.WriteLine(GetRandomDouble(double.MinValue, double.MaxValue));
            Console.WriteLine(GetRandomDouble(double.MinValue, double.MaxValue));
            Console.WriteLine(GetRandomDouble(double.MinValue, 100.0));
            Console.WriteLine(GetRandomDouble(double.MinValue, 100.0));
            Console.WriteLine(GetRandomDouble(double.MinValue, 100.0));
            Console.WriteLine(GetRandomDouble(double.MinValue, 100.0));
            Console.WriteLine(GetRandomDouble(double.MinValue, 100.0));
            Console.WriteLine(GetRandomDouble(double.MinValue, 100.0));
            Console.WriteLine(GetRandomDouble(double.MinValue, 100.0));
            Console.WriteLine(GetRandomDouble(double.MinValue, 100.0));
            Console.WriteLine(GetRandomDouble(double.MinValue, 100.0));
            Console.WriteLine(GetRandomDouble(double.MinValue, 100.0));
            Console.WriteLine(GetRandomDouble(-100, double.MaxValue));
            Console.WriteLine(GetRandomDouble(-100, double.MaxValue));
            Console.WriteLine(GetRandomDouble(-100, double.MaxValue));
            Console.WriteLine(GetRandomDouble(-100, double.MaxValue));
            Console.WriteLine(GetRandomDouble(-100, double.MaxValue));
            Console.WriteLine(GetRandomDouble(-100, double.MaxValue));
            Console.WriteLine(GetRandomDouble(-100, double.MaxValue));
            Console.WriteLine(GetRandomDouble(-100, double.MaxValue));
            Console.WriteLine(GetRandomDouble(-100, double.MaxValue));
            Console.WriteLine(GetRandomDouble(-100, double.MaxValue));
            Console.ReadLine();
        }
        private static Random rng = new Random();
        private static double GetRandomDouble(double min, double max)
        {
            // Get the base value, scale first and then shift.
            return rng.NextDouble()*(max - min) + min;
        }
    }
