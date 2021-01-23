    private static IEnumerable GetHashSet(IEnumerable source)
    {
        var inputType = source.GetType();
        if (!inputType.IsGenericType || inputType.IsGenericTypeDefinition)
            throw new ArgumentException(nameof(source));
        var genericArgumentType = inputType.GetGenericArguments()[0];
        var iEnumerableType = typeof (IEnumerable<>).MakeGenericType(genericArgumentType);
        if (!iEnumerableType.IsAssignableFrom(inputType))
            throw new ArgumentException(nameof(source));
        var ctor = typeof (HashSet<>).MakeGenericType(genericArgumentType)
            .GetConstructor(new[] {iEnumerableType});
        if (ctor == null)
            throw new Exception("ctor not found.");
        return ctor.Invoke(new object[] { source }) as IEnumerable;
    }
