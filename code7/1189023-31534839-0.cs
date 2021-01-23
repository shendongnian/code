    public static class ListSearching
    {
      public static bool Contains<T>(this IList<T> haystack, IList<T> needle)
      {
        return Contains(haystack, needle, null);
      }
      public static bool Contains<T>(this IList<T> haystack, IList<T> needle, IEqualityComparer<T> cmp)
      {
        return haystack.IndexOf(needle, cmp) != -1;
      }
      public static int IndexOf<T>(this IList<T> haystack, IList<T> needle)
      {
        return IndexOf(haystack, needle, null);
      }
      public static int IndexOf<T>(this IList<T> haystack, IList<T> needle, IEqualityComparer<T> cmp)
      {
        if(haystack == null || needle == null)
          throw new ArgumentNullException();
        int needleCount = needle.Count;
        if(needleCount == 0)
          return 0;//empty lists are everywhere!
        if(cmp == null)
          cmp = EqualityComparer<T>.Default;
        int count = haystack.Count;
        if(needleCount == 1)//can't beat just spinning through for it
        {
          T item = needle[0];
          for(int idx = 0; idx != count; ++idx)
            if(cmp.Equals(haystack[idx], item))
              return idx;
          return -1;
        }
        int m = 0;
        int i = 0;
        int[] table = KMPTable(needle, cmp);
        while(m + i < count)
        {
          if(cmp.Equals(needle[i], haystack[m + i]))
          {
            if(i == needleCount - 1)
              return m == needleCount ? -1 : m;//match -1 = failure to find conventional in .NET
            ++i;
          }
          else
          {
            m = m + i - table[i];
            i = table[i] > -1 ? table[i] : 0;
          }
        }
        return -1;
      }
      private static int[] KMPTable<T>(IList<T> sought, IEqualityComparer<T> cmp)
      {
        int[] table = new int[sought.Count];
        int pos = 2;
        int cnd = 0;
        table[0] = -1;
        table[1] = 0;
        while(pos < table.Length)
          if(cmp.Equals(sought[pos - 1], sought[cnd]))
            table[pos++] = ++cnd;
          else if(cnd > 0)
            cnd = table[cnd];
          else
            table[pos++] = 0;
        return table;
      }
    }
