        static void Main(string[] args)
        {
            Test(i => i > 3);
        }
        static void Test(Func<int, bool> f)
        {
            IEnumerable<int> k = new [] {5, 4, 3, 22,1};
            foreach (var i in k.Where(f))
                Console.WriteLine(i);
        }
