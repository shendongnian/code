    class A
    {
        // private by default 
        static string Foo()
        {
            return "This is class A";
        }
    }
    class B
    {
        public void Foo()
        {
            var name = A.Foo(); // error, cannot access, A.Foo must be public
        }
    }
