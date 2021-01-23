    public static class IEnumerableExtenstions
    {
        static void PrintCollection<T>(this IEnumerable<T> collection)
        {
            foreach (T p in collection)
                Console.WriteLine(Convert.ToString(p));
        }
    }
