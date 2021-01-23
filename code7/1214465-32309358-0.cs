    List<int> list = new List<int> {
      0, 1, 3, 4, 9, 10, 15
    };
    
    // if the list is ordered, you don't need this
    list.Sort();
    
    // if list is dense 
    int result = list[list.Count - 1] + 1;
    
    // check for "holes", providing that list values are unique (list[i - 1] != list[i])
    for (int i = 1; i < list.Count; ++i)
      if (list[i - 1] + 1 != list[i]) {
        result = list[i - 1] + 1;
    
        break;
      }
