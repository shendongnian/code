    public static class EnumerableExtensions
    {
        public static HashSet<T> ToHashSet(this IEnumerable<T> enumerable)
        {
            return new HashSet<T>(enumerable);
        }
    }
    Random rnd = new Random();
    var trainList = Enumerable.Range(1, inputLines.Length)
                              .OrderBy(x => rnd.Next())
                              .Take(train)
                              .ToHashSet();
    var testList = new List<int>();
    for (int i = 1; i <= inputLines.Length; i++)
    {
        if (!trainList.Contains(i))
            testList.Add(i);
    }
