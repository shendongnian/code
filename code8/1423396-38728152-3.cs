    [Pure, NotNull]
    public static IEnumerable<IEnumerable<T>> AsEnumerableOfEnumerables<T>(
       [NotNull] this T[,] p2DArray
    ) {
       var height = p2DArray.GetLength(0);
       for (var row = 0; row < height; row++)
          yield return p2DArray.GetPartialEnumerable(row);
    }
    [Pure, NotNull]
    public static IEnumerable<T> GetPartialEnumerable<T>(
       [NotNull] this T[,] p2DArray,
       int pRow
    ) {
       var width = p2DArray.GetLength(1);
       for (var col = 0; col < width; col++)
          yield return p2DArray[pRow, col];
    }
    [Pure, NotNull]
    public static T[,] To2DArray<T>(
       [NotNull] this IEnumerable<IEnumerable<T>> pJaggedArray
    ) {
       if (!pJaggedArray.Any() || !pJaggedArray.First().Any())
          return new T[0, 0];
       var height = pJaggedArray.Count();
       var width = pJaggedArray.First().Count();
       var result = new T[height, width];
       var r = 0;
       foreach (var subArray in pJaggedArray) {
          if (subArray == null || subArray.Count() != width)
             throw new InvalidOperationException("Jagged array was not rectangular.");
          var c = 0;
          foreach (var item in subArray)
             result[r, c++] = item;
          r += 1;
       }
         
       return result;
    }
