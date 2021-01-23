    public static void Show<T>(this IList<T> list)
    {
        var str = String.Join(Environment.NewLine, list);
        Console.WriteLine(str);
    }
