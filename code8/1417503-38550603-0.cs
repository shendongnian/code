    extern alias assembly1;
    extern alias assembly2;
    
    using FirstClass = assembly1::Foo.SomeClass;
    using SecondClass = assembly2::Foo.SomeClass;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var c1 = new FirstClass();
                var c2 = new SecondClass();
            }
        }
    }
