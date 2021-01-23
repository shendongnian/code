    public class B
    {
      public string Name { get; set; }
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
        _b.Name = "New Name";
      } 
    }
