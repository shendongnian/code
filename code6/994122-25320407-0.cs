    public static class Extensions
    {
        public static void AddMany<T>(this List<T> list, params T[] input)
        {
            list.AddRange(input);
        }
    }
