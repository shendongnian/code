    var countByOtherId = db.EntityToOrder
        .GroupBy(e => e.OtherId)
        .Select(g => new { ID = g.Key, Count = g.Count() })
        .ToDictionary(e => e.ID, e => e.Count);
    
    var other = new Dictionary<long, string>();
    int skipCount = startIndex, useCount = 0;
    foreach (var e in db.OtherEntity.OrderBy(e => e.Name))
    {
        int count;
        if (!countByOtherId.TryGetValue(e.ID, out count)) continue;
        if (skipCount > 0 && other.Count == 0)
        {
            if (skipCount >= count) { skipCount -= count; continue; }
            count -= skipCount;
        }
        other.Add(e.ID, e.Name);
        if ((useCount += count) >= pageSize) break;
    }
    
    
    var entities = db.EntityToOrder
        .Where(e => other.Keys.Contains(e.OtherId))
        .AsEnumerable()
        .Select(e => new EntityToOrder { ID = e.ID, Name = e.Name, 
            OtherId = e.OtherId, OtherName = other[e.OtherId] })
        .OrderBy(e => e.OtherName).ThenBy(e => e.Name)
        .Skip(skipCount).Take(pageSize)
        .ToList();
