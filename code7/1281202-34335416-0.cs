    class B : I1
    {
        protected void A()
        {
            Console.WriteLine("Implicit ");
        }
        void void I1.A()
        {
            Console.WriteLine("Explicit");
        }
    }
    I1 i = new B();
    i.A(); // works
    B b = new B();
    b.A(); // does not work
