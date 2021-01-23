    public static IEnumerable<T> Empty<T>()
    {
        return new T[] {};
    }
    
    public static IEnumerable<T> Cons<T>(T head, IEnumerable<T> tail)
    {
        yield return head;
        foreach (var t in tail)
            yield return t;
    }
    public static IEnumerable<IEnumerable<T>> Crossproduct<T>(IEnumerable<IEnumerable<T>> sets)
    {
        if (!sets.Any())
            return new[] {Empty<T>()};
    
        var head = sets.First();
        var tailCross = Crossproduct<T>(sets.Skip(1));
    
        return
            from h in head
            from ts in tailCross
            select Cons(h, ts);
    }
