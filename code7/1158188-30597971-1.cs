    var idLookup = Collection1.Select(x => x.ID)
        .Concat(Collection2.Select(x => x.ID))
        .Concat(Collection3.Select(x => x.ID))
        .ToLookup(id => id);
    foreach(var g in idLookup)
    {
        otherCollection.Add(g.Key);
        // you get the count in this way:
        int count = g.Count();
    }
