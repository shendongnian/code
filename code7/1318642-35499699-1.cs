    public class A
    {
        protected A()
        {
            ...
        }
    
        protected Boolean IsCorrect() {...}
    
        public static A Create() {
          result A = new A();
    
          if (!IsCorrect())     
            return null;
          else
            return result;
        }
    }
    
    public class B : A
    {
        protected B() :base()
        {
           ...        
        }
    
        public static B Create() { 
          result B = new B();
    
          if (!IsCorrect())     
            return null;
          else
            return result; 
        }
    }
....
      B value = B.Create(); // instance of B or null
