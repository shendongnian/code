    class A
    {
        public int a1 { get; set; }
    }
    class B
    {
        public A a = new A();
        public B()
        {
            a.a1 = 45; //you need to put that in a method..
        }
    }
    class C
    {
        B b = new B();   // instance of B in C
        int aValue = b.a.a1;  // access b's instance of A
    }
