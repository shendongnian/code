        static void Main(string[] args)
        {
            WriteMultiLine(1,2, "hello", TimeSpan.FromMinutes(3));
            Console.ReadLine();
        }
        public static void WriteMultiLine(params object[] values)
        {
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
        }
