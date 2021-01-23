    public class A
    {
        public B Instance_B;
    
        public A(B b)
        {
             Instance_B = b;
        }
    }
    
    public class B
    {
        public A Instance_A;
    
        public B()
        {
             Instance_A = new A(this);
        }
    }
