        private static void Main(string[] args)
        {
            using (Class1 c1 = new Class1(1))
            {
                using (Class1 c2 = new Class1(2))
                {
                    Class1 c3 = new Class1(3);
                }
            }
            Console.ReadKey();
        }
        class Class1 : IDisposable
        {
            int x;
            public Class1(int a)
            {
                x = a;
            }
            public void Dispose()
            {
                Console.WriteLine(x + "object disposing");
            }
        }
