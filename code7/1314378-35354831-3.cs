    public class A 
    { 
      private BWrapper _b;
      public A(BWrapper b)
      { 
        _b = b;
        // do stuff
      } 
      public string FuncOne()
      { 
        _b.B = newB;
        //somehow change value of B 
      } 
    }
