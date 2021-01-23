    if (!CacheHelper.Get("AllRoles", out entities))   
    {
    var items = _context.Set<Roles>().ToList();
    entities = items;
    var cachableEntities = entities.ToList();
    CacheHelper.Add(cachableEntities, "AllRoles");
    }
        
    return entities;
