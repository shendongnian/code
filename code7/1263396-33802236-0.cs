      public class InMemoryDatabase
      {
          private Dictionary<Type, IEnumerable> _hashSets = new Dictionary<Type, IEnumerable>();
          // Returns or creates a new HashSet for this type.
          public HashSet<T> GetCollection<T>()
          {
              Type t = typeof(T);
              if (!_hashSets.HasKey(t))
              {
                  _hashSets[t] = new HashSet<T>();
              }
              
              return (_hashSets[t] as HashSet<T>);
           }
        }
