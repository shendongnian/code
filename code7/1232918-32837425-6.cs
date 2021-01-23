    public class Child : Parent 
    {
      private string name;
    
      public Child()
      {
        name = "My Name";
      }
    
      public override int Name
      { 
        get 
        { 
          // NullReferenceException here.
          // You didn't expect that this code is executed before
          // the constructor was, did you?
          name.Substring(0, name.Length - 1);
        } 
      }
    }
