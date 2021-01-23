    var c = Database.Set<Photo>().
        Where(p => string.IsNullOrEmpty(userId) || p.ClientProfileId == userId).
        OrderBy(p => orderBy == OrderBy.TimeOfCreation ? p.TimeOfCreation : p.AverageRaiting).
        Skip((page - 1) * pageSize).Take(pageSize);
    return c
