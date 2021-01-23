    class Wrapper
    {
        readonly A a;
        readonly B b;
        public Wrapper(A a)
        {
            this.a = a;
        }
        public Wrapper(B b)
        {
            this.b = b;
        }
        public DateTime Date => a?.Date ?? b.Date;
        public void Print()
        {
            if (a != null)
                a.Print();
            else
                b.Print();
        }
    }
