    List<int> initA = new List<int>();
    for (int i = 0; i < m; i++)
         initA.SetValueAtIndex(i, i);
    public static void SetValueAtIndex<T>(this IList<T> list, int index, T value)
    {
      while (list.Count <= index + 1)
      {
        list.Add(default(T));
      }
      list[index] = value;
    }
