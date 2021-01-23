    static void Main()
    {
        IEnumerable<Foo> typed = new Foo[0];
        IEnumerable<object> untyped = typed;
        Console.WriteLine(typed.GetByGenerics());     // Foo
        Console.WriteLine(untyped.GetByGenerics());   // Object
        Console.WriteLine(typed.GetByReflection());   // Foo
        Console.WriteLine(untyped.GetByReflection()); // Foo
    }
    public static string GetByGenerics<T>(this IEnumerable<T> list)
    {
        return typeof(T).Name;
    }
    public static string GetByReflection<T>(this IEnumerable<T> list)
    {
        var name =
            from abstraction in list.GetType().GetInterfaces()
            where abstraction.IsGenericType
            && abstraction.GetGenericTypeDefinition() == typeof(IEnumerable<>)
            from genericArgumentType in abstraction.GetGenericArguments()
            select genericArgumentType.Name;
        return name.Single();
    }
