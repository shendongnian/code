    class C 
    {
      private List<int> myList = new List<int>();
      // Only the code in C can add items to the list.
      public IEnumerable<int> Items 
      {
        get
        {
          return from item in myList select item;
        }
      }
    }
