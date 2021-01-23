        public static void Print(dynamic value)
        {
            Console.WriteLine(value);            
        }
        public static void GenericFunc(dynamic value)
        {
            Print(value);
        }
        static void Main(dynamic[] args)
        {
            GenericFunc((dynamic)"Hello World");
        }
