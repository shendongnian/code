    public class Super {
      public virtual string Name {get {return "super";}}
    }
    public class Sub1 : Super {
      override public string Name {get {return "sub1";}}
    }
