    static class IListExtensions
    {
       private static Random _rnd = new Random();
       public static void PickRandom<T>(this IList<T> items) =>
           return items[_rnd.Next(items.Count)];
    }
