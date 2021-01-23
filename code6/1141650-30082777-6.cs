    class Parent { }
    class Son : Parent { }
    
    class Daughter : Parent { }
    class MainClass
    {
      private void IDictionary<Type, Action<Parent>> map =
        new Dictionary<Type, Action<Parent>>()
        {
          // If you need to do anything fancy with the target
          // you can safely cast inside the lambda here
          // e.g. x => Console.WriteLine((Son)x.ToString())
          { typeof(Son), x => ...SOME CODE... }
          { typeof(Daughter), x => ...SOME CODE... }
        }
      private void Iterate(IEnumerable<Parent> list)
      {
        foreach (Parent item in list) {
            map[item.GetType()](item);
        }
      }
    }
