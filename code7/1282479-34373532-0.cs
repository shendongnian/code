    var itemMap = new Dictionary<Guid, Permission>();
    foreach (var list in permissionLists)
    {
        foreach (var item in list)
        {
            Permission other;
            if (!itemMap.TryGetValue(item.Id, out other) || (item.HasPermission && !other.HasPermission))
                itemMap[item.Id] = item;
        }
    }
    var result = itemMap.Values.Where(item => !item.HasPermission).ToList();
