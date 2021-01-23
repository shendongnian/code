     class Program
        {
            static void Main(string[] args)
            {
                A.field = "2";
                var a = A.field;
                
    
                Console.WriteLine(a);
                Console.Read();
            }
        }
    
        public static class A
        {
            public static  string field = "1";
        }
