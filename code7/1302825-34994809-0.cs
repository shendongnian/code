    class A
    {
        public B b { get; set; }
    }
    
    class B
    {
        int x;
    
        public static implicit operator B(bool b) 
        {
            return b ? new B { x = 1 } : new B { x = 0 };
        }
    
        public static explicit operator bool(B b)
        {
            return b.x > 0;
        }
    
        public static bool operator true(B d1)
        {
            return d1.x > 0;
        }
    
        public static bool operator false(B d1)
        {
            return !(d1.x > 0);
        }
    
        public static B operator &(B d1, B d2) 
        {
            return d1.x > 0 && d2.x > 0;
        }
    
        public static B operator |(B d1, B d2)
        {
            return d1.x > 0 || d2.x > 0;
        }
    }
