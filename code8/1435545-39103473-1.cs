    class AutoIndexDictionary : IEnumerable<Whatever>
    {
      private readonly Dictionary<int, Whatever> myDict = new Dictionary<int, Whatever>();
    
      private int currentIndex = 0;
    
      public int Add(Whatever item)
      {
        var myIndex = currentIndex 
        myDict.Add(myIndex, item);
        currentIndex ++;
        return myIndex;
      }
      
      public void Remove(int index)
      {
        myDict.Remove(index);
      }
    
      // implement IEnumerable, indexer etc.
      // ...
    }
