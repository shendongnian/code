    interface IGetThing<T>
    { 
      T Get();
    }
    class BaseGetter<A> : IGetThing<A> 
      where A : new()
    {
      public A Get()
      {
        A result;
        GetInternal(out result);
        return result;
      }
   
      protected virtual void GetInternal(out A target)
      {
        target = new A();
      }
    }
  
    class DerivedGetter<B, A> : BaseGetter<A>, IGetThing<B> 
      where B : A, new() 
      where A : new()
    {
      public new B Get()
      {
        B result;
        GetInternal(out result);
        return result;
      }
  
      protected override void GetInternal(out A target)
      {
        target = Get();
      }
  
      protected virtual void GetInternal(out B target)
      {
        target = new B();
      }
    }
    
    class Derived2Getter<C, B, A> : DerivedGetter<B, A>, IGetThing<C>
      where C : B, new()
      where B : A, new()
      where A : new()
    {
      public new C Get()
      {
        C result;
        GetInternal(out result);
         return result;
      }
  
      protected override void GetInternal(out B target)
      {
        target = Get();
      }
   
      protected virtual void GetInternal(out C target)
      {
        target = new C();
      }
    }
