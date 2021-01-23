    public static class Test
    {
        public static int First<T>(this T obj)
        {
            Console.WriteLine("Compile-time type: {0}", typeof(T));
            Console.WriteLine("Execution-time type: {0}", obj.GetType());
            return 2;
        }
    
        public static int Second(this object obj)
        {
            // No compile-time type to know about
            Console.WriteLine("Execution-time type: {0}", obj.GetType());
            return 2;
        }
    }
