    Dictionary<Type1, Type2> d = new Dictionary<Type1, Type2>();
    var entriesToBeRemoved = d.GroupBy(x => x.Value.SomeId)
                             .SelectMany(x => x.Skip(1))
                             ;
    foreach (var kvp in entriesToBeRemoved)
    {
        d.Remove(kvp.Key);
    }
