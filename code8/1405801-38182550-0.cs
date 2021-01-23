    static void Main()
    {
        IEnumerable<Foo> typed = new Foo[0];
        IEnumerable<object> untyped = typed;
        Console.WriteLine(typed.GetGenericTypeDefinitionName());
        Console.WriteLine(untyped.GetGenericTypeDefinitionName());
    }
    public static string GetGenericTypeDefinitionName<T>(this IEnumerable<T> list)
    {
        return typeof(T).Name;
    }
