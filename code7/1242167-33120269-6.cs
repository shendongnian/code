    class A
    {
        static string Foo() { return "Class A"; }
    
        public class B
        {
            public static string Foo() { return A.Foo(); } // no error
        }
    }
    Console.WriteLine(B.Foo());
