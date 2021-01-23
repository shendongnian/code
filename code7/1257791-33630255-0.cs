      static IEnumerable<T1> M<T1>(IEnumerable<T1> objEnumerable, Func<T1, bool> wherePredicate)
      {
          return objEnumerable.Where(predicate);
      }
      
      -- calling like 
      var listOfBObjects = GetBObjectIEnumerable();
      C instanceOfC  = GetCClassObject();
      M<B>(listOfBObjects, b => b.A.Name = instanceOfC.Name);
