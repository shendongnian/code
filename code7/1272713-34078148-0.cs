        public static int func1(int x, int y, string minMax)
        {
            return (int)typeof(Math).GetMethod(minMax, new[] { typeof(int), typeof(int) }).Invoke(null, new object[] { x, y });
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("Max Wanted :" + func1(1, 2, "Max"));
            Console.WriteLine("Min Wanted :" + func1(1, 2, "Min"));
        }
