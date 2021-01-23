    class A
    {
        public int a1 { get; set; }
    }
    class B
    {
        A a = new A();
        
        public void SetA1(int val)
        {
            a.a1 = val;
        }
    }
    class C
    {
        B b = new B();   // instance of B in C
        public C()
        {
            b.SetA1(45);
        }
    }
