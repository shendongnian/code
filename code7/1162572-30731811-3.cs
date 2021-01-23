    Dictionary<Type1, Type2> d = new Dictionary<Type1, Type2>();
    var entriesToBeRemoved = d.GroupBy(x => x.Value.SomeId)
                              .ToDictionary(x => x.Skip(1).First().Key, x => x.Skip(1).First().Value)
                             ;
    foreach (Type1 key in entriesToBeRemoved.Keys)
    {
        d.Remove(key);
    }
