    public static void Main(string[] args)
    {
        var values = new List<int>() { 100, 110, 120 };
        var funcs = new List<Func<int>>();
        using (var enumerator = values.GetEnumerator())
        {
            int v;
            while (enumerator.MoveNext())
            {
                v = enumerator.Current;
                funcs.Add(() => v);
            }
        }
        foreach (var f in funcs)
            Console.WriteLine(f());
    }
