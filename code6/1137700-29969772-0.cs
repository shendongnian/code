        public static void Main(string[] args)
        {
            Console.WriteLine(Mul());
            Console.ReadKey(true);
        }
        public static double Add()
        {
            return EvaluateConst() + EvaluateConst();
        }
        public static double Mul()
        {
            return EvaluateConst() * Add();
        }
        public static double EvaluateConst()
        {
            return 2;
        }
