    namespace X
    {
        public static class N
        {
            public static int Plus(this int i)
            {
                return i + 10;
            }
        }
    }
    namespace ConsoleApplication1
    {
        public static class M
        {
            public static int Plus(this int i, int p = 6)
            {
                return i + p;
            }
        }
        internal class Program
        {
            private static void Main()
            {
                int i = 3.Plus();
                Console.WriteLine(i);
            }
        }
    }
