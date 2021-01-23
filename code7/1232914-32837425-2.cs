    public class Child : Parent 
    {
      private string name;
    
      public Child()
      {
        name = "My Name";
      }
    
      public override int NameLength 
      { 
        get 
        { 
          // NullReferenceException here.
          // You didn't expect that this code can be executed before
          // the constructor was, did you?
          return name.Length; 
        } 
      }
    }
