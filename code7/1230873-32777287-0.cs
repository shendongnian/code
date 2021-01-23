    MethodInfo info = typeof(Enumerable)
        .GetMethods(BindingFlags.Static | BindingFlags.Public)
        .Where(x => x.Name.Contains("SequenceEqual"))
        .Single(x => x.GetParameters().Length == 2);
    Type genericType = typeof(IEnumerable<>).MakeGenericType(infos.GetGenericArguments());
