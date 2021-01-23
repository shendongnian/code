    public class A
    {
        public int prop1 { get; set; }
        public int prop2 { get; set; }
    }
    
    // Define other methods and classes here
    public class B : A
    {
       public B(A a)
       {
          //base = a; doesn't work.
          base.prop1 = a.prop1;
          base.prop2 = a.prop2;
       }
    }
