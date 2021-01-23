    class AutoIndexDictionary : IEnumerable<Whatever>
    {
      private readonly Dictionary<int, Whatever> myDict = new Dictionary<int, Whatever>();
    
      private int lastIndex = 0;
    
      public Add(Whatever item)
      {
        myDict.Add(lastIndex++, item);
      }
      
      public Remove(int index)
      {
        myDict.Remove(index);
      }
    
      // implement IEnumerable, indexer etc.
      // ...
    }
