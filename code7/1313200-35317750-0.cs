    class Program
    {
        static void Main(string[] args)
        {
            List<Func<int>> tests = new List<Func<int>>() { T1, T2, T3 };
            Func<int> test = tests.First(t => t() != 0);
            Console.WriteLine("Test is " + test.Method.Name);
        }
        static int T1() { return 0; }
        static int T2() { return 1; }
        static int T3() { return 1; }
    }
