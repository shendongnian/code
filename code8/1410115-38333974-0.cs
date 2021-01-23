    public TList2 DoSomething<TList1, TList2>(TList1 strings) 
        where TList1 : IEnumerable<string>
        where TList2 : ICollection<decimal>, new()
    {
        var result = new TList2();
        foreach (var s in strings)
        {
            result.Add(decimal.Parse(s));
        }
        return result;
    }
