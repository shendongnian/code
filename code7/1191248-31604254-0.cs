        class Program
        {
            static void Main(string[] args)
            {
                var o = new object();
                if (o.IsNull())
                {
                    Console.Write("null");
                }
            }
        }
    
        public static class Request
        {
            public static bool IsNull(this object obj)
            {
                return ReferenceEquals(obj, null);
            }
        }
