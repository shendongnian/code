    var entities = mainContext.EntityToOrder;
    var otherIds = entities.Select(e => e.OtherID).ToList();
    Dictionary<long, string> otherNames = secondContext.OtherEntity
        .Where(oe => otherIds.Contains(oe.ID))
        .Select(oe => new { ID = oe.ID, Name = oe.Name })
        .ToDictionary(oe => oe.ID, oe => oe.Name);
    
    Func<EntityToOrder, KeyValuePair<long, string>, EntityToOrder> joinFunc = ((a, b) => { 
        a.OtherName= b.Value;
        return a;
    });
    return entities.Join(otherNames, e => e.OtherID, oe => oe.Key, joinFunc)
        .OrderBy(e => e.OtherName)
        .Skip(startIndex)
        .Take(pageSize)
        .ToList();
