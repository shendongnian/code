    public class A
    {
        public A Method1()
        {
            return this;
        }
    }
    public class B : A
    {
        public new B Method1()
        {
            return (B)base.Method1();
        }
    }
