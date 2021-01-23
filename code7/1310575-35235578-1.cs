    class Program
    {
        static void Main(string[] args)
        {
            Func1();
            Console.WriteLine("\n");
            Func2();
            Console.ReadKey();
        }
        private static void Func1()
        {
            int i = 0;
            var list = new List<int> { 1, 2, 3 };
            list.ForEach(x => Console.WriteLine(++i));
        }
        private static void Func2()
        {
            int i = 0;
            int j = ++i;
            var list = new List<int> { 1, 2, 3 };
            list.ForEach(x => Console.WriteLine(j));
        }
    }
