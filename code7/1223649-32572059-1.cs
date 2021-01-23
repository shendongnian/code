    public static List<string> GetAllPossibleCombos(List<List<string>> strings)
    {
        IEnumerable<string> combos = new [] { "" };
        foreach (var inner in strings)
            combos = from c in combos
                     from i in inner
                     select c + i;
        return combos.ToList();
    }
    static void Main(string[] args)
    {
        var x = GetAllPossibleCombos(
            new List<List<string>>{
                new List<string> { "a", "b", "c" },
                new List<string> { "x", "y" },
                new List<string> { "1", "2", "3", "4" }});
    }
