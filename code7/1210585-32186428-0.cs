    public static IList<T> TakeLast<T>(this IEnumerable<T> enumerable, int n)
    {
        var queue = new Queue<T>(n);
        foreach(var item in enumerable)
        {
            queue.Enqueue(item);
            if(queue.Count > n)
                queue.Dequeue();
        }
        return queue.ToList();
    }
