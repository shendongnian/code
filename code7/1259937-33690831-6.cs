      // Are you given List<int>? What about int[]? IEnumerable<int> is a much better choice 
      public static IEnumerable<Tuple<int, int>> FindTwoSum(IEnumerable<int> items, int sum) {
        // Validate Arguments (the method is public one!)
        if (null == items)
          throw new ArgumentNullException("items");
    
        var list = items.ToList();
    
        for (int i = 0; i < list.Count - 1; ++i)   // last line doesn't count
          for (int j = i + 1; j < list.Count; ++j) // note j = i + 1
            // if ((list[i] + list[j] == sum) && (list[i] != list[j])) { // distinct values and indexes
            if (list[i] + list[j] == sum) { // distinct indexes only
              yield return new Tuple<int, int>(i, j);
              yield return new Tuple<int, int>(j, i);                
            }
      }
