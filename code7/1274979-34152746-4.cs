      Dictionary<int, int[]> source = new Dictionary<int, int[]>() {
        {1, new int[] { 1, 5, 7, 5, 5, 3, 4, 9}},
        {2, new int[] { 0, 1, 2, 3, 4, 6, 3, 4}},
        {3, new int[] { 9, 4, 6, 7, 0, 0, 3, 1}},
        {4, new int[] { 4, 6, 3, 7, 8, 0, 0, 1}},
        {5, new int[] { 8, 0, 3, 1, 0, 2, 4, 6}},
      };
      var result = source
        .Select(pair => pair.Value
           .Where(item => item > pair.Key + 1)
           .ToArray());
