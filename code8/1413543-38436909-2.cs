        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                if (IsArmstrong(i.ToString()))
                    Console.WriteLine(i + " " + IsArmstrong(i.ToString()));
            }
            Console.WriteLine($"DONE in {sw.ElapsedMilliseconds} ms");
            sw.Restart();
            for (int i = 0; i < 100000; i++)
            {
                if (IsArmstrong2(i.ToString()))
                    Console.WriteLine(i + " " + IsArmstrong2(i.ToString()));
            }
            Console.WriteLine($"DONE in {sw.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
        public static bool IsArmstrong(string numValue)
        {
            int sum = 0;
            int intValue = Int32.Parse(numValue);
            for (int i = intValue; i > 0; i = i / 10)
            {
                sum = sum + (int)Math.Pow(i % 10, 3.0);
            }
            if (sum == intValue)
                return true;
            else
                return false;
        }
        public static bool IsArmstrong2(string numValue)
        {
            int n;
            if (!int.TryParse(numValue, out n))
            {
                throw new Exception($"{numValue} not a number");
            }
            int c = 0, a;
            int temp = n;
            while (n > 0)
            {
                a = n % 10;
                n = n / 10;
                c = c + (a * a * a);
            }
            if (temp == c)
                return true;
            else
                return false;
        }
