    using System;
    public class C {   
        public void M()
        {
            A(5);
            A(5m);
        }
        
        public void A(decimal d)
        {
            decimal whyyy = d * 5.5m;        
        }       
    }
