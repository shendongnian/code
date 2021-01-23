    public class A
    {
        public A(A a)
        {
           prop1 = a.prop1;
           prop2 = a.prop2; 
        }
        int prop1 { get; set; }
        int prop2 { get; set; }
    }
    
    public class B : A
    {
       public B(A a) : base (a)
       {
          
       }
    }
    
    A a = new A();
    B b = new B(a);
