    public class B<T>
    {
      public <T> Value { get; set; }//object can be any type
    }
    
    public abstract class A<T> 
    { 
      private B<T> _b;
      public A(B<T> b)
      { 
        _b = b;
        //do stuff 
      } 
      public abstract string FuncOne();
    }
