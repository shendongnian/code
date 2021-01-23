    class Program
    {
        static void Main(string[] args)
        {
            const int maxIterations = 100000;
            var infinityDetected = false;
            for (int i = 0; i < maxIterations; i++)
            {
                var d = GetRandomDouble(double.MinValue, double.MaxValue);
                if (double.IsInfinity(d))
                {
                    infinityDetected = true;
                    Console.WriteLine("Infinity detected");
                    break;
                }
                Console.WriteLine(d);
            }
            if (!infinityDetected)
            {
                for (int i = 0; i < maxIterations; i++)
                {
                    var d = GetRandomDouble(-1.0, double.MaxValue);
                    if (double.IsInfinity(d))
                    {
                        infinityDetected = true;
                        Console.WriteLine("Infinity detected");
                        break;
                    }
                    Console.WriteLine(d);
                }
            }
            if (!infinityDetected)
            {
                for (int i = 0; i < maxIterations; i++)
                {
                    var d = GetRandomDouble(double.MinValue, 1.0);
                    if (double.IsInfinity(d))
                    {
                        Console.WriteLine("Infinity detected");
                        break;
                    }
                    Console.WriteLine(d);
                }
            }
            Console.ReadLine();
        }
        private static Random rng = new Random();
        private static double GetRandomDouble(double min, double max)
        {
            // Get the base value, scale first and then shift.
            return rng.NextDouble() * (max - min) + min;
        }
    }
