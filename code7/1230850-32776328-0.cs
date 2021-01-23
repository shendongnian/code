    var oldUserEntities = userEntities.ToList();
    var newUserEntities = userEntities.Select(i => new UserEntity
    {
        RowKey = dict[i.RowKey],
        // rest of desired properties ...
    }).ToList();
