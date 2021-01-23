    public static void WriteLines<T> (this IEnumerable<T> @this)
    {
        foreach (T item in @this)
            Console.WriteLine(item);
    }
