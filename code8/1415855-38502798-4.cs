    public static IEnumerable<T[]> SplitArray<T>(T[] source, int size) {
      if (null == source)
        throw new ArgumentNullException("source");
      else if (size <= 0)
        throw new ArgumentOutOfRangeException("size", "size must be positive");
      int n = source.Length / size + (source.Length % size > 0 ? 1 : 0);
      for (int i = 0; i < n; ++i) {
        T[] item = new T[i == n - 1 ? source.Length - size * i : size];
        Array.Copy(source, i * size, item, 0, item.Length);
        yield return item;
      }
    }
