    public class B
    {
      public object Value { get; set; }//object can be any type
    }
    
    public class A 
    { 
      private B _b;
      public A(B b)
      { 
        _b = b;
        //do stuff 
      } 
      public string FuncOne()
      { 
        //somehow change value of B 
        _b.Value = NewValue;
      } 
    }
