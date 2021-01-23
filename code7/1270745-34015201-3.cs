    public static void PrintSequence<T>(IEnumerable<T> queue)
    {
        foreach (T item in queue)
        {
            Console.WriteLine(item);
        }
    }
