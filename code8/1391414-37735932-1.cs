        static void Main(string[] args)
        {
            Foo foo;
            ComplexType complexType;
            using (var newFoo = new Foo())
            {
                foo = newFoo;
                complexType = newFoo.ComplexType;
            }
            Console.WriteLine(complexType.SomeProperty); // This works :)
            Console.WriteLine(foo.ComplexType.SomeProperty); // Throws an exception because ComplexType is NULL
            Console.ReadKey();
        }
