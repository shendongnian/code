    class Program
    {
        static void Main(String[] args)
        {
            Console.WriteLine(RoundAndFormat(1));
            Console.WriteLine(RoundAndFormat(10));
            Console.WriteLine(RoundAndFormat(100));
            Console.WriteLine(RoundAndFormat(1000));
            Console.WriteLine(RoundAndFormat(100000));
            Console.WriteLine(RoundAndFormat(125000));
            Console.WriteLine(RoundAndFormat(125900));
            Console.WriteLine(RoundAndFormat(1000000));
            Console.WriteLine(RoundAndFormat(1250000));
            Console.WriteLine(RoundAndFormat(1258000));
            Console.WriteLine(RoundAndFormat(10000000));
            Console.WriteLine(RoundAndFormat(10500000));
            Console.WriteLine(RoundAndFormat(100000000));
            Console.WriteLine(RoundAndFormat(100100000));
            Console.ReadLine();
        }
        public static String RoundAndFormat(Int32 value)
        {
            var result = String.Empty;
            var negative = value < 0;
            if (negative) value = value * -1;
            if (value < 1000)
            {
                result = value.ToString();
            }
            else if (value < 1000000)
            {
                result = RoundDown(value / 1000.0, 0) + "K";
            }
            else if (value < 100000000)
            {
                result = RoundDown(value / 1000000.0, 2) + "M";
            }
            else if (value < 10000000000)
            {
                result = RoundDown(value / 1000000.0, 0) + "M";
            }
            if (negative) return "-" + result;
            return result;
        }
        public static Double RoundDown(Double value, Int32 digits)
        {
            var pow = Math.Pow(10, digits);
            return Math.Truncate(value * pow) / pow;
        }
