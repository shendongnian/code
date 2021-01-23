        static void Main(string[] args)
        {
            Console.WriteLine(AreSame("", ""));
            Console.WriteLine(AreSame("", null));
            Console.WriteLine(AreSame(null, ""));
            Console.WriteLine(AreSame(null, null));
            Console.Read();
        }
        private static bool AreSame(string x, string y)
        {
            return (string.IsNullOrEmpty(x) == string.IsNullOrEmpty(y));
        }
