    class MyClass                          interface IEnumerable
    {                                      {
       public bool IsNextAvailablle()          public bool MoveNext()
       {                                       {
          // implementation
       }                                       }
    
       public SomeObject GetNext()             public SomeObject Current
       {                                       {
          return nextObject;                       get { ... }
       }                                       }
    }                                      }
