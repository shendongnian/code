    internal class Program
    {
        public Program()
        {
        }
        private static void Main(string[] args)
        {
            Test test = new Test();
            try
            {
                test.Foo();
            }
            finally
            {
                if (test != null)
                {
                    ((IDisposable)test).Dispose();
                }
            }
            Console.ReadLine();
        }
    }
