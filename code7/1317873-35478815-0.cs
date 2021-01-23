    class A
    {
        ...
        public A(B b)
        {
            this.Bees = new List<B>();
            this.Bees.Add(b);
        }
    }
    
    class B
    {
        ...
        public B(A a)
        {
            this.MyA = a;
        }
    }
