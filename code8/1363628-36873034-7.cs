        static void Main(string[] args)
        {
            var foo = new SubClass(42);
            Console.WriteLine(foo.Value);
            Console.WriteLine(((BaseClass)foo).Value);
            Console.ReadKey();
        }
