    List<IEnumerable> coll = new List<IEnumerable>();
    
    coll.Add(new List<string> { "a", "b" });
    coll.Add(new List<int> { 7 });
    foreach (var item in coll)
    {
        var args = item.GetType().GetGenericArguments();
        foreach (var genericArg in args)
        {
            Console.WriteLine(genericArg); // generic types (e.g. string, int)
        }
    }
