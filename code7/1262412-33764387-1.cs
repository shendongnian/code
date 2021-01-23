    public class A
    {
        public A() { }
    
        public int A1 { get; set; }
    }
    
    public class B
    {
        public B()
        {
            this._a = new A() { A1 = 42 };
        }
    
        private A _a;
    
        public A A
        {
            get { return _a; }
        }
    }
    
    public class C
    {
        public C() { }
    
        public int GetA1FromA()
        {
            return new B().A.A1;
        }
    }
