    public class C
    {
        A _a;
        public C(A a)
        {
            _a = a;
        }
        void Do() // Using constructor parameter.
        {
            Console.WriteLine(_a.a1); // Should print 45, so long as your other code has already ran.
        }
    
        void Do(B b) // Using method parameter.
        {
            Console.WriteLine(b.A.a1); // will write 45
        }
    }
