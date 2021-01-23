    class ListArray {
      private readonly List<object>[] _lists;
      private readonly int _capacity;
    
      public ListArray(int size, int capacity) {
        _lists = new List<object>[size];
        _capacity = capacity;
      }
    
      public List<object> this[int ix] {
        get { 
          if( _lists[ix] == null ) 
            _lists[ix] = new List<object>(capacity);
          return _lists[ix]
        }
      }
    }
