    public static IEnumerable<T> GetRow<T>(this T[,] array, int index)
    {
      int last = array.GetUpperBound(1);
      for(int idx = array.GetLowerBound(1); idx <= last; ++idx)
        yield return array[index, idx];
    }
