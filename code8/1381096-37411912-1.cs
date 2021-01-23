    public static class Extensions
    {
        public static void ForEach<ST>(this IEnumerable<ST> source, Action<ST> action)
        {
            IEnumerator<ST> enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                action(enumerator.Current);
        }
    }
