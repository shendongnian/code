      int n = new int[] {
        list1.Count,
        list2.Count,
        list3.Count,
        // etc.
      }.Min(); // if lists have different number of items
    
      for (int i = 0; i < n; ++i) {
        var item1 = list1[i]; // if you want an item
        ...
      }
