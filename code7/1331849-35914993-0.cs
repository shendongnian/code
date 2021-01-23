    public class ValueListManager
    {
      public static Operations myOps { get { return new Ops(); } }         
    }
    public class Ops : Operations
    { 
      internal Ops() {}
      public void Call()
      {
      }
    }
