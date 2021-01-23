    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int r = 5;
            var combinations = Math.Pow(r, n);
            var list = new List<string>();
            for (Int64 i = 1; i < combinations; i++)
            {
                var s = LongToBase(i);
                var fill = n - s.Length;
                list.Add(new String('0', fill) + s);
            }
            // list contains all your paths now
            Console.ReadKey();
        }
        private static readonly char[] BaseChars = "01234".ToCharArray();
        public static string LongToBase(long value)
        {
            long targetBase = BaseChars.Length;
            char[] buffer = new char[Math.Max((int)Math.Ceiling(Math.Log(value + 1, targetBase)), 1)];
            var i = (long)buffer.Length;
            do
            {
                buffer[--i] = BaseChars[value % targetBase];
                value = value / targetBase;
            }
            while (value > 0);
            return new string(buffer);
        }
    }
