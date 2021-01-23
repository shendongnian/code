    public static class Program
    {
        private static bool b;
        public static void Main()
        {
            b = true;
            Console.WriteLine(b);
            DoStuff();
            Console.WriteLine(b);
        }
        private static void DoStuff()
        {
            b = false;
        }
    }
