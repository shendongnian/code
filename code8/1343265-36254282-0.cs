    public static bool AtLeast<T>(this IEnumerable<T> collection, int n)
    {
        if (n < 1)
            return true; // or exception, you choose
        if (n == 1)
            return collection.Any();
        return collection.Skip(n - 1).Any();
    }
