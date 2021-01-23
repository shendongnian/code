    public class A {
      public int Id {get;set;}
      public int BId {get;set;}
      public virtual B B {get;set;}
    }
    public class B{
      public int Id {get;set;}
      public virtual ICollection<A> AColl {get;set;}
    }
