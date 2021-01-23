        public static void Print<T>(T value) where T : class
        {
            if (value != null)
            {
                Console.WriteLine(value.ToString());
            }
        }
        public static void GenericFunc<T>(T value) where T : class
        {
            Print(value);
        }
