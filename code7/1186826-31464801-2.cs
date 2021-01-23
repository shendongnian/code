    public static int ScrambledEqualsComparable<TKey, T>(
      IDictionary<TKey, T> list1, 
      IDictionary<TKey, T> list2)
        where TKey : IComparable
        where T : IComparable
    {
      return ScrambledEquals(list1, list2);
    }
    public static int ScrambledEqualsCompareAsHtml<TKey, T>(
      IDictionary<TKey, T> list1, 
      IDictionary<TKey, T> list2)
        where TKey : IComparable
        where T : ICompareAsHtml 
    {
      return ScrambledEquals(list1, list2);
    }
    private static int ScrambledEquals<TKey, T>(
      Dictionary<TKey, T> list1, 
      Dictionary<TKey, T> list2)
        where TKey : IComparable
    {
      // the same as above code - No need to throw exception as 
      // it has to be one of ICompareAsHtml or IComparable.
    }
