    private static Dictionary<long, int> s_Counts = new Dictionary<long, int>() {
      {1, 1},
    };
    private static void AppendCounts(long n) {
      List<long> list = new List<long>();
      for (; !s_Counts.ContainsKey(n); n = n % 2 == 0 ? n / 2 : 3 * n + 1) 
        list.Add(n);
      int count = s_Counts[n];
      for (int i = list.Count - 1; i >= 0; --i)
        s_Counts.Add(list[i], count + list.Count - i);
    }
    ...
    for (int i = 1; i < 1000000; ++i)
      AppendCounts(i);
    KeyValuePair<long, int> max = new KeyValuePair<long, int>(0, 0);
    foreach (var pair in s_Counts)
      if (pair.Value > max.Value)
        max = pair;
    Console("{0} generates {1} values", max.Key, max.Value); 
