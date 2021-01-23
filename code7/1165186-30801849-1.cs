    public static class Extensions
    {
        public static IEnumerable<T> GetRange<T>(this IList<T> list, int startIndex, int endIndex)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                yield return list[i];
            }
        }
    }
    foreach(var item in list.GetRange(0, 5))
    {
         Console.WriteLine(item);
    }
