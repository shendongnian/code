    class Parent { }
    class Son : Parent { }
    
    class Daughter : Parent { }
    class MainClass
    {
      // If you don't actually need a reference to the child
      private void IDictionary<Type, Action> map =
        new Dictionary<Type, Action>()
        {
          { typeof(Son), () => ...SOME CODE... }
          { typeof(Daughter), () => ...SOME CODE... }
        };
      // If you do need a reference to the child
      private void IDictionary<Type, Action<Parent>> otherMap =
        new Dictionary<Type, Action<Parent>>()
        {
          { typeof(Son), x => (Son)x. ...SOME CODE... }
          { typeof(Daughter), y => (Daughter)x. ...SOME CODE... }
        };      
      private void Iterate(IEnumerable<Parent> list)
      {
        foreach (Parent item in list) {
            // either
            map[item.GetType()]();
            // or
            otherMap[item.GetType()](item);
        }
      }
    }
