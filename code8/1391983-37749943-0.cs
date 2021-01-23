      int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      int size = 3;
      var result = Enumerable
        .Range(0, a.Length / size + (a.Length % size == 0 ? 0 : 1))
        .Select(index => a
           .Skip(index * size)
           .Take(size)
           .ToArray()); // if you want IEnumerable<int[]>
