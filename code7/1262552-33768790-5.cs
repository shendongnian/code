    class A
    {
        public virtual void M(A a) { Console.WriteLine("A.M"); }
    }
    class B : A
    {
        public override void M(A a) { Console.WriteLine("B.M"); }
    }
