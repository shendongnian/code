    public static class ListExtensions
    {
        public static IEnumerable<T> TakeOrDefault<T>(this List<T> list, int count, T defaultValue)
        {
            int missingItems = count - list.Count;
            List<T> extra = new List<T>(missingItems);
            for (int i = 0; i < missingItems; i++)
                extra.Add(defaultValue);
            return list.Take(count).Concat(extra);
        }
    }
