    class Parent { }
    class Son : Parent { }
    
    class Daughter : Parent { }
    class MainClass
    {
      private void Iterate(IEnumerable<Parent> list)
      {
        foreach (Parent item in list) {
            Visit((dynamic)item);
        }
      }
      private void Visit(Son son)
      {
        ...SOME CODE...
      }
      private void Visit(Daughter daughter)
      {
        ...SOME CODE...
      }
    }
