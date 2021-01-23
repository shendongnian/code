    public class Wrapper
    {        
        public Wrapper(int Prop)
        {
            this.Prop = Prop;
        }
    
        public static explicit operator Wrapper(A a)
        {
            return new Wrapper(a.Prop);
        }
    
        public static explicit operator Wrapper(B b)
        {
            return new Wrapper(b.Prop);
        }
    
        public int Prop { get; set; }
    }
    
    //Extension method still the same...
