    class Parent
    {
      public abstract void DoSomething();
    }
    class Son : Parent
    {
      public override void DoSomething()
      {
        ...SOME CODE...
      }
    }
    
    class Daughter : Parent
    {
      public override void DoSomething()
      {
        ...SOME CODE...
      }
    }
    class MainClass
    {
      private void Iterate(IEnumerable<Parent> list)
      {
        foreach (Parent item in list) {
            item.DoSomething();
        }
      }
    }
