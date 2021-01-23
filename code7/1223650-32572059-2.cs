    public static IEnumerable<IEnumerable<string>> GetAllPossibleCombos(
        IEnumerable<IEnumerable<string>> strings)
    {
        IEnumerable<IEnumerable<string>> combos = new string[][] { new string[0] };
        foreach (var inner in strings)
            combos = from c in combos
                     from i in inner
                     select c.Append(i);
        return combos;
    }
    public static IEnumerable<TSource> Append<TSource>(
        this IEnumerable<TSource> source, TSource item)
    {
        foreach (TSource element in source)
            yield return element;
        yield return item;
    }
    static void Main(string[] args)
    {
        var combos = GetAllPossibleCombos(
            new List<List<string>>{
                new List<string> { "a", "b", "c" },
                new List<string> { "x", "y" },
                new List<string> { "1", "2", "3", "4" }});
        var result = combos.Select(c => string.Join(",", c)).ToList();
    }
