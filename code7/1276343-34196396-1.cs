    var c = Database.Set<Photo>().
        Where(p => string.IsNullOrEmpty(userId) || p.ClientProfileId == userId).
        OrderBy(p => orderBy == OrderBy.TimeOfCreation ? p.TimeOfCreation : DateTime.Now).
        ThenBy(p => orderBy == OrderBy.AverageRaiting ? p.AverageRaiting : 0.0).
        Skip((page - 1) * pageSize).Take(pageSize);
    return c
