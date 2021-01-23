    class A
    {
        public int a1 { get; set; }
    }
    class B
    {
        A a = new A();
        public int A_Value
        {
            get { return a.a1; }
            set { a.a1 = value; }
        }
    }
    class C
    {
        B b = new B();   // instance of B in C
        public C()
        {
            b.A_Value = 45;
        }
    }
