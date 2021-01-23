    class Program
    {
        static int x = 0;
    
        static int f()
        {
            x = x + 10;
            return 1;
        }
    
        public static void Main()
        {
            x = f() + x;
            System.Console.WriteLine(x);
        }
    }
