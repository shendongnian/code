    private static IEnumerable GetHashSet(IEnumerable source)
    {
        var type = source.GetType().GetGenericArguments()[0];
        var ctor = typeof(HashSet<>).MakeGenericType(type)
                    .GetConstructor(new[] {typeof (IEnumerable<>).MakeGenericType(type)});
        return ctor.Invoke(new object[] { source }) as IEnumerable;
    }
