      int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      int size = 3;
      // Array of 3 items arrays
      int[][] result = Enumerable
        .Range(0, a.Length / size + (a.Length % size == 0 ? 0 : 1))
        .Select(index => a
           .Skip(index * size)
           .Take(size)
           .ToArray()) 
        .ToArray(); // if you want array of 3-item arrays
