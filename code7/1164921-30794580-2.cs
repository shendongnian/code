    public static Guid GetUUIDByTableName(this Profile value, string tableName)
    {
        switch (tableName)
        {
            case "A_": return value.A_UUID;
            case "B_": return value.B_UUID;
            default: return Guid.Empty;
        }
    }
    
    
    List<Profile> profilesFromUUID = await MobileService.GetTable<Profile>()
        .Where(p => p.GetUUIDByTableName(handler.Name) == obj.uuid)
        .ToListAsync();
