        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (long i = 0; i < 100000; i++)
            {
                if (IsArmstrong(i.ToString()))
                    Console.WriteLine(i + " " + IsArmstrong(i.ToString()));
            }
            Console.WriteLine($"DONE in {sw.ElapsedMilliseconds} ms");
            sw.Restart();
            for (long i = 0; i < 100000; i++)
            {
                if (IsArmstrong2(i.ToString()))
                    Console.WriteLine(i + " " + IsArmstrong2(i.ToString()));
            }
            Console.WriteLine($"DONE in {sw.ElapsedMilliseconds} ms");
            Console.WriteLine(IsArmstrong2("548834"));
            Console.ReadKey();
        }
        public static bool IsArmstrong(string numValue)
        {
            long sum = 0;
            long longValue = long.Parse(numValue);
            for (long i = longValue; i > 0; i = i / 10)
            {
                sum = sum + (long)Math.Pow(i % 10, numValue.Length);
            }
            if (sum == longValue)
                return true;
            else
                return false;
        }
        public static bool IsArmstrong2(string numValue)
        {
            long n;
            if (!long.TryParse(numValue, out n))
            {
                throw new Exception($"{numValue} not a number");
            }
            long c = 0, a;
            long temp = n;
            while (n > 0)
            {
                a = n % 10;
                n = n / 10;
                c = c + (int)Math.Pow(a,numValue.Length);
            }
            if (temp == c)
                return true;
            else
                return false;
        }
