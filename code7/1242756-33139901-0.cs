    public static IEnumerable<IEnumerable<T>>
    GetPermutationsInner<T>(IEnumerable<IGrouping<T, T>> groupedList, int length)
    {
        if (length == 1) return groupedList.Select(t => new T[] { t.Key });
        return GetPermutationsInner<T>(groupedList, length - 1)
            .SelectMany(t => groupedList
                    .Where(e => t.Count(w => w.Equals(e.Key)) < e.Count())
                    .Select(s => s.Key),
                (t1, t2) => t1.Concat(new T[] { t2 }));
    }
    public static IEnumerable<IEnumerable<T>>
        GetPermutations<T>(IEnumerable<T> list)
    {
        var resultList = new List<IEnumerable<T>>();
        for (int i = 1; i <= list.Count(); ++i)
        {
            resultList.AddRange(GetPermutationsInner<T>(list.GroupBy(g => g), i));
        }
        return resultList;
    }
