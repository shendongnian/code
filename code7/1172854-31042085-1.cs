        private static void a(int arg)
        {
            Console.WriteLine("a called: " + arg);
        }
        private static void b(int arg)
        {
            Console.WriteLine("b called: "+arg);
        }
        public static void run(Action<int> action, int arg)
        {
            action(arg);
        }
        private static void Main(string[] args)
        {
            run(a, 1);
            run(b, 2);
            Console.ReadLine();
        }
  
