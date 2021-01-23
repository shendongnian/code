    public class N {}
    public class B<T> 
    {
        public class N {}
    }
    
    public class D : B<N> // base class
    {
      N n;  // field
    }
