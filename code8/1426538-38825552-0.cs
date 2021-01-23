    public class A
    {
        public A(string x = null, int y = -1)
        {
        }
    }
    
    public class B : A
    {
        public B(string x) : base(x)
        {
        }
    }
    
    public class B2 : A
    {
        public B(int y) : base(y)
        {
        }
    }
    // You can even inherit A and don't call the A's constructor
    // because all parameters are optional
    public class B3 : A
    {
    }
