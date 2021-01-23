    public static DictionaryExtensions {
      public static Dictionary<K, int> Subtract(this IDictionary<K, int> first, 
                                                     IDictionary<K, int> second) {
        if (null == first)
          return null; // or throw new ArgumentNullException("first");  
        else if (null == second)
          return first.ToDictionary(pair => pair.Key, pair => pair.Value); // let it be copy
                 // or throw new ArgumentNullException("second");  
    
        Dictionary<K, int> result = new Dictionary<K, int>();
    
        foreach (var pair in first) {
          int secondNum;
    
          if (second.TryGetValue(pair.Key, out secondNum)) 
            if (pair.Value > secondName) 
              result.Add(pair.Key, pair.Value - secondNum);
        }
    
        return result;
      }
    }
