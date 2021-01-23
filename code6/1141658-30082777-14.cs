    class Parent
    {
      public abstract void Accept(IChildVisitor visitor);
    }
    class Son : Parent
    {
      public override void Accept(IChildVisitor visitor)
      {
        visitor.Visit(this);
      }
    }
    
    class Daughter : Parent
    {
      public override void Accept(IChildVisitor visitor)
      {
        visitor.Visit(this);
      }
    }
    interface IChildVisitor
    {
      Visit(Son son);
      Visit(Daughter daughter);
    }
    class SomeCodeChildVisitor : IChildVisitor
    {
      public Visit(Son son)
      {
        ...SOME CODE...
      }
      public Visit(Daughter daughter)
      {
        ...SOME CODE...
      }
    }
    class MainClass
    {
      private void Iterate(IEnumerable<Parent> list)
      {
        foreach (Parent item in list) {
            item.Accept(new SomeCodeChildVisitor());
        }
      }
    }
