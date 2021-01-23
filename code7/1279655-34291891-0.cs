    public static class ListExtensions
    {
        public static List<List<T>> split<T>(this List<T> source, int sizeOfList) 
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / sizeOfList)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
