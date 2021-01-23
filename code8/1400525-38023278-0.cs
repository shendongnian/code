    var query = query.OrderBy(sorts[0]);
    for(var i = 1; i < sorts.Length; i++) 
    {
        query = query.ThenBy(sorts[i]);
    }
    // It will became like query.OrderBy(a => a.A).ThenBy(a => a.B).ThenBy(a => a.C)...
